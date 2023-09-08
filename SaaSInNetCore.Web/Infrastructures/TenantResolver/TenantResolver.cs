using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SaasKit.Multitenancy;
using SaaSInNetCore.Data.Contexts;
using SaaSInNetCore.Data.Entities.Catalog;

namespace SaaSInNetCore.Web.Infrastructures.TenantResolver
{
    public class TenantResolver : ITenantResolver<Tenant>
    {

        private readonly CatalogDbContext _context;

        public TenantResolver(CatalogDbContext context)
        {
            _context = context;
        }


        public Task<TenantContext<Tenant>> ResolveAsync(HttpContext context)
        {
            TenantContext<Tenant> tenantContext = null;

            var tenant = _context.Tenants.FirstOrDefault(t =>
                t.HostName.Equals(context.Request.Host.Value.ToLower()));

            if (tenant != null)
            {
                tenantContext = new TenantContext<Tenant>(tenant);
            }

            return Task.FromResult(tenantContext);
        }
    }
}
