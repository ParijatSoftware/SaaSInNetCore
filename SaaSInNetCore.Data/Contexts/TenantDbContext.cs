using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaaSInNetCore.Data.Entities.Tenant;
using SaaSInNetCore.Data.Infrastrutures.Extensions;
using SaaSInNetCore.Data.Entities.Catalog;

namespace SaaSInNetCore.Data.Contexts
{
    public sealed class TenantDbContext : IdentityDbContext<TenantUser>
    {

        private readonly Tenant _currentTenant;
        public TenantDbContext(Tenant currentTenant)
        {
            _currentTenant = currentTenant;
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_currentTenant != null)
                optionsBuilder.UseSqlServer(_currentTenant.GetConnectionString(), options => options.MigrationsAssembly("SaaSInNetCore.Web"));

            base.OnConfiguring(optionsBuilder);
        }

    }
}
