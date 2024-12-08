using Microsoft.EntityFrameworkCore;
using UserPersonAuditAPI.Models.Base;
using UserPersonAuditAPI.Models.Basic;

namespace UserPersonAuditAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Register all entities manually
            //modelBuilder.Entity<ApplicationUser>();
            modelBuilder.Entity<Image>();
            //modelBuilder.Entity<Person>();
            //modelBuilder.Entity<StakeHolder>();
            //modelBuilder.Entity<StakeHolderType>();

            // Add your custom configurations (e.g., global settings)
            ApplyGlobalConfigurations(modelBuilder);
        }

        private void ApplyGlobalConfigurations(ModelBuilder modelBuilder)
        {
            // Example of global configurations

            // 1. Global delete behavior restriction
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // 2. Ensure RecordId is unique
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var recordIdProperty = entityType.FindProperty("RecordId");
                if (recordIdProperty != null)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .HasIndex(nameof(BaseEntity<Guid>.RecordId))
                        .IsUnique();
                }
            }

            // 3. Set table and column naming conventions
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (!string.IsNullOrEmpty(tableName))
                {
                    tableName = tableName.ToUpperInvariant();
                    entityType.SetTableName(tableName);
                }                
            }
        }
    }

}
