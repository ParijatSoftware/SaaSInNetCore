using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaaSInNetCore.Data.Entities.Tenant;
using SaaSInNetCore.Data.Contexts;

namespace SaaSInNetCore.Web.Infrastructures.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {

            services.AddIdentity<TenantUser, IdentityRole>()
                .AddEntityFrameworkStores<TenantDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }


        public static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration, string migrationsAssembly)
        {

            services.AddCatalogDbContext(configuration, migrationsAssembly)
                    .AddTenantDbContext();

            return services;
        }

    }
}
