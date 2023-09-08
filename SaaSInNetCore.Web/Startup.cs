using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaaSInNetCore.Web.Infrastructures.Extensions;
using SaaSInNetCore.Web.Infrastructures.Helpers.DbHelper;
using SaaSInNetCore.Web.Infrastructures.TenantResolver;
using SaaSInNetCore.Data.Entities.Catalog;

namespace SaaSInNetCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddContexts(Configuration, migrationAssembly);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentityService();

            //Two options available, resolved tenant from db in each request or from cache
            //services.AddMultitenancy<Tenant, TenantResolver>();
            services.AddMultitenancy<Tenant, MemoryCacheTenantResolver>();
            services.AddControllersWithViews();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();

            app.UseCookiePolicy();
            app.UseMultitenancy<Tenant>();
            app.UseAuthentication();
            app.UseAuthorization();

            DbInitailizer.InitializeDatabase(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
