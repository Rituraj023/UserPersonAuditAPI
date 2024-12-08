using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserPersonAuditAPI.Models.Identity;

namespace UserPersonAuditAPI.Data
{
    public class IdentityContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        ulong,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Apply global cascade restrict for all foreign key relationships
            ApplyGlobalCascadeRestrict(modelBuilder);

            // 2. Register specific entities and relationships
            ConfigureEntities(modelBuilder);

            // 3. Set table naming conventions
            ApplyTableNamingConventions(modelBuilder);

            // 4. Global mapping: ulong to bigint
            MapUlongToBigint(modelBuilder);
        }

        private void ApplyGlobalCascadeRestrict(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }
        }

        private void ConfigureEntities(ModelBuilder modelBuilder)
        {
            // Example: ApplicationUser and StakeHolder relationship
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(au => au.StakeHolder)
                      .WithMany()
                      .HasForeignKey(au => au.StakeHolderId);
            });

            // Example: Composite key for ApplicationUserRole
            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(r => new { r.UserId, r.RoleId });
            });

            // Configure additional entities and relationships if needed
            modelBuilder.Entity<StakeHolderType>();
            modelBuilder.Entity<Person>();
            modelBuilder.Entity<StakeHolder>();
        }

        private void ApplyTableNamingConventions(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (!string.IsNullOrEmpty(tableName))
                {
                    // Remove "AspNet" prefix if present
                    if (tableName.StartsWith("AspNet", StringComparison.InvariantCultureIgnoreCase))
                    {
                        tableName = tableName.Substring(6); // Remove the "AspNet" prefix
                    }

                    // Convert table name to uppercase
                    tableName = tableName.ToUpperInvariant();

                    // Apply schema and updated table name
                    entityType.SetTableName(tableName);
                    entityType.SetSchema("Identity");
                }
            }
        }

        private void MapUlongToBigint(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(ulong))
                    {
                        property.SetColumnType("bigint");
                        if (property.IsPrimaryKey())
                        {
                            property.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                        }
                    }
                }
            }
        }

    }
}
