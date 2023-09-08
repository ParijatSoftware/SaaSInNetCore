﻿using SaaSInNetCore.Data.Entities.Catalog;

namespace SaaSInNetCore.Data.Infrastrutures.Extensions
{
    public static class ContextConfigurationExtensions
    {

        /// <summary>
        /// Build current tenant's database connection string based on its database server name and database name
        /// </summary>
        /// <param name="currentTenant"></param>
        /// <returns></returns>
        public static string GetConnectionString(this Tenant currentTenant)
        {

            //Replace placeholder of connection string and set current tenant server name and database name
            //Build complete connection string and return
            var connectionString = currentTenant.DbConnectionString
                .Replace("{SNC_DbServer}", currentTenant.Server)
                .Replace("{SNC_DbName}", currentTenant.Database);

            return connectionString;
        }

    }
}
