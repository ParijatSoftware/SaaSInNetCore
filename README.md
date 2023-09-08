# SaaSInNetCore
SaaS app using .Net Core. Uses Net Core 7.0.

## Known Issue
Currently `HTTPS` redirection is not supported.

## Application Architecture
Nothing Complex.

I followed a separate database per tenant approach.

In `SaaSInNetCore.Data` project, there are two different contexts. 
+ `CatalogDbContext` holds global tenant-level data like tenant configuration
+ `TenantDbContext` holds tenant-specific data like tenant user, other tenant-related data

## Steps to run the application
+ Create migration file if not created (but it's already created under `Data` folder of `SaaSInNetCore.Web`). If you want to re-create migration later check `TempFiles` folder in `SaaSInNetCore.Web` for migration scripts. Run `Catalog Database` migration only.
+ Run application. Application will create Catalog database (if not already created) and seed it with Tenant Data.
+ For testing purposes, I have configured application to listen requests on host `http://*.localhost:6001` (you can find configuration in `Program.cs` file.) Default seeding only added two tenant which hostname are `http://rshop.localhost:6001` and `http://jshop.localhost:6001`  therefore request from only these two hostname will be resolved else tenant will not resolve. You can find seeding in `SaaSInNetCore.Web > Infrastructures > Helpers > DbHelper` folder.
+ Once application is running, go to `http://rshop.localhost:6001` and `http://jshop.localhost:6001` you can find same site for two tenant but pointing to a different databases.
+ You can also perform user signup and login operations in these tenants. Those operations happens in Tenant specific database.
