using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SS.Template.Api.ApiKeyAuth
{
    public class ApiKeyAuthenticationSchemeHandler : AuthenticationHandler<ApiKeyAuthenticationSchemeOptions>
    {
        public ApiKeyAuthenticationSchemeHandler(IOptionsMonitor<ApiKeyAuthenticationSchemeOptions> options,
                                           ILoggerFactory logger,
                                           UrlEncoder encoder,
                                           ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var apiKeyHeader = Context.Request.Headers
                .FirstOrDefault(h => h.Key.Equals("X-API-KEY", StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(apiKeyHeader.Value) || apiKeyHeader.Value != Options.ApiKey)
            {
                return Task.FromResult(AuthenticateResult.Fail($"Invalid X-API-KEY"));
            }
            var claims = new[] { new Claim(ClaimTypes.Name, "VALID USER") };
            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
