using Microsoft.EntityFrameworkCore;
using SaaSInNetCore.Data.Infrastrutures.Extensions;
using SaaSInNetCore.Data.Entities.Catalog;

namespace SaaSInNetCore.Data.Contexts
{
    public class CatalogDbContext : DbContext
    {

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {

        }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.TenantConfiguration();
        }


    }
}
