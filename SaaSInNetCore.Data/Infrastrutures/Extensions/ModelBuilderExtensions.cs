using Microsoft.EntityFrameworkCore;
using SaaSInNetCore.Data.Entities.Catalog;

namespace SaaSInNetCore.Data.Infrastrutures.Extensions
{
    public static class ModelBuilderExtensions
    {

        public static ModelBuilder TenantConfiguration(this ModelBuilder builder)
        {
            builder.Entity<Tenant>()
                .ToTable("Tenant");

            return builder;

        }

    }
}
