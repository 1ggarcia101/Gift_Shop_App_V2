using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using SS.Artemis.Proxy;
using SS.Template.Api.ApiKeyAuth;
using SS.Template.Application.Commands;
using SS.Template.Application.Features.Examples;
using SS.Template.Application.Infrastructure;
using SS.Template.Core;
using SS.Template.Core.Persistence;
using SS.Template.Infrastructure;
using SS.Template.Infrastructure.DependencyInjection;
using SS.Template.Persistence;

namespace SS.Template.Api
{
    public class Startup
    {
        private const string AssetsDirectory = "assets";

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder =>
                builder.AllowAnyHeader()
                        .WithExposedHeaders(HeaderNames.ContentDisposition)
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins(Configuration["Origins"].Split(';')));

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var applicationAssembly = typeof(ExamplesMapping).Assembly;

            services.AddControllers();

            services.AddHealthChecks();

            AddAuthentication(services, Configuration);

            AddAppServices(services, applicationAssembly);
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            var key = configuration["KeycloakSigningKey"];
            var apiKey = configuration["ApiKeySecret"];
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        RequireExpirationTime = true,
                        RequireSignedTokens = true,
                        RequireAudience = false,
                        ValidateActor = false,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new X509SecurityKey(new X509Certificate2(Convert.FromBase64String(key)))
                    };
                })
                .AddScheme<ApiKeyAuthenticationSchemeOptions, ApiKeyAuthenticationSchemeHandler>(
                    "ApiKey",
                    opts => opts.ApiKey = apiKey
                );
            services.AddAuthorization();
        }

        /// <summary>
        /// Automatically registers validators for <see cref="Edit{T,TResponse}" /> commands.
        /// </summary>
        /// <param name="services">The services.</param>
        private static void AddEditCommandValidators(IServiceCollection services)
        {
            var descriptors = new List<ServiceDescriptor>();

            foreach (var descriptor in services.Where(x => IsClosedType(x.ServiceType, typeof(IRequestHandler<,>))))
            {
                var commandType = descriptor.ServiceType.GetGenericArguments()[0];
                if (commandType.BaseType != null && IsClosedType(commandType.BaseType, typeof(EditBase<>)))
                {
                    var modelType = commandType.BaseType.GetGenericArguments()[0];
                    var validatorInterfaceType = typeof(IValidator<>).MakeGenericType(commandType);
                    var validatorConcreteType = typeof(EditValidator<,>).MakeGenericType(commandType, modelType);
                    descriptors.Add(ServiceDescriptor.Transient(validatorInterfaceType, validatorConcreteType));
                }
            }

            foreach (var descriptor in descriptors)
            {
                services.Add(descriptor);
            }
        }

        private static bool IsClosedType(Type type, Type openGenericType)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == openGenericType;
        }

        private void AddAppServices(IServiceCollection services, Assembly applicationAssembly)
        {
            // Swagger
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // DbContext's
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<AppDbContextInitializer>();

            // Persistence
            services.AddTransient<IRepository, EfRepository<AppDbContext>>();
            services.AddTransient<IReadOnlyRepository, ReadOnlyEfRepository<AppDbContext>>();
            services.AddSingleton<IPaginator, DefaultPaginator>();
            services.AddSingleton<IFilterCriteria, FilterCriteria>();
            //Proxys
            services.AddHttpContextAccessor();
            services.AddHttpClient<IJanusProxy, JanusBambooProxy>(client =>
            {
                client.DefaultRequestHeaders.Add("X-API-KEY", Configuration.GetValue<string>("ApiKeySecret"));
            });


            // Infrastructure
            services.AddSingleton<IDateTime>(new SystemDateTime(Configuration["TZ"]));
            services.AddAutoMapper(AutoMapperConfig.Configure, applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly);

            if (Environment.IsDevelopment())
            {
                var root = Path.Join(Environment.ContentRootPath, AssetsDirectory);
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                services.AddSingleton<IFileSystem>(new LocalFileSystem(root));
                services.AddSingleton<IUrlService>(new DomainUrlService(Configuration.GetValue<Uri>("AssetsDomain"), AssetsDirectory,
                    Configuration.GetValue<Uri>("ClientDomain")));
                // If SMTP configuration exists for development, use it
                if (!RegisterSmtpSender(services, false))
                {
                    services.AddSingleton<IEmailSender>(new DummyEmailSender(Path.Join(Environment.ContentRootPath, "Logs")));
                }
            }
            else
            {
                RegisterSmtpSender(services, required: true);
                services.AddSingleton<IUrlService>(new DomainUrlService(Configuration.GetValue<Uri>("AssetsDomain"), null,
                    Configuration.GetValue<Uri>("ClientDomain")));
            }

            // Services
            services.AddServices(applicationAssembly);

            // MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            AddEditCommandValidators(services);
        }

        private bool RegisterSmtpSender(IServiceCollection services, bool required)
        {
            var smtpSection = Configuration.GetSection("SMTP");
            var children = smtpSection.GetChildren();
            if (!children.Any())
            {
                if (required)
                {
                    throw new SettingsException("No SMTP configuration found.");
                }

                return false;
            }

            services.ConfigureAndValidate<SmtpSettings>(smtpSection);
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            return true;
        }
    }
}
