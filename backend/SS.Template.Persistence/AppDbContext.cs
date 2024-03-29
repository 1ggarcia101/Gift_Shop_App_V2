using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;
using SS.Template.Persistence.Migrations;

namespace SS.Template.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Example> Examples { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Interviewers> Interviewers { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<DesirableSkill> DesirableSkills { get; set; }
        
        public DbSet<JobDescriptions> JobDescriptions { get; set; }

        public DbSet<SoftSkill> SoftSkills { get; set; }

        public DbSet<SpecificWorkExperienceRequirement> WorkExperienceRequirements { get; set; }

        public DbSet<TechnicalKnowledges> TechnicalKnowledges { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        public DbSet<TechSkill> TechSkills { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // To add new migrations, open a Command Prompt on the project directory and run:
            // dotnet ef migrations add <MigrationName> --context AppDbContext --startup-project ../SS.Template.Api --output-dir Migrations

            // To apply migrations
            // dotnet ef database update --context AppDbContext --startup-project ../SS.Template.Api

            // To revert migrations
            // dotnet ef migrations script <FromMigration> <ToMigration> --context AppDbContext --startup-project ../SS.Template.Api --output revert.sql
            // Note: Use 0 to refer to the state before any migrations
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var type = entity.ClrType;

                if (type.GetInterfaces().Any(i => IsClosedTypeOf(i, typeof(IStatus<>))))
                {
                    modelBuilder.Entity(type).HasIndex(nameof(IStatus<string>.Status));
                }

                // Remove pluralization
                if (!typeof(ValueObject).IsAssignableFrom(type))
                {
                    entity.SetTableName(type.Name);
                }
            }
        }

        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private static bool IsClosedTypeOf(Type type, Type genericInterfaceType)
        {
            return type.IsGenericType &&
                   type.GetGenericTypeDefinition() == genericInterfaceType;
        }

        private void BeforeSaveChanges()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                switch (dbEntityEntry.State)
                {
                    case EntityState.Added:
                        SetDateCreated(dbEntityEntry);
                        SetDateUpdated(dbEntityEntry);
                        break;

                    case EntityState.Modified:
                        SetDateUpdated(dbEntityEntry);
                        break;

                    default:
                        break;
                }
            }
        }

        private static void SetDateCreated(EntityEntry dbEntityEntry)
        {
            if (dbEntityEntry.Entity is IHaveDateCreated haveDateCreated)
            {
                haveDateCreated.DateCreated = DateTime.UtcNow;
            }
        }

        private static void SetDateUpdated(EntityEntry dbEntityEntry)
        {
            if (dbEntityEntry.Entity is IHaveDateUpdated haveDateUpdated)
            {
                haveDateUpdated.DateUpdated = DateTime.UtcNow;
            }
        }
    }
}
