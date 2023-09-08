using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaaSInNetCore.Data.Contexts;

namespace SaaSInNetCore.Web.Infrastructures.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddCatalogDbContext(this IServiceCollection services, IConfiguration configuration, string migrationAssembly)
        {
            services.AddDbContext<CatalogDbContext>(builder =>
                builder.UseSqlServer(configuration.GetConnectionString("CatalogConnection"),
                    options => options.MigrationsAssembly(migrationAssembly)));
            return services;
        }


        public static IServiceCollection AddTenantDbContext(this IServiceCollection services)
        {
            services.AddDbContext<TenantDbContext>();
            return services;
        }
    }
}
