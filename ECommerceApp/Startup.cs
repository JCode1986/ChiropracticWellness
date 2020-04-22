using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.Data;
using ECommerceApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECommerceApp.Models.Interface;
using ECommerceApp.Models.Services;

namespace ECommerceApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddRazorPages();

            //registering the Identity database
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //local
                //options.UseSqlServer(Configuration.GetConnectionString("IdentityDefault"));

                //deployed
                options.UseSqlServer(Configuration.GetConnectionString("ProductionIdentityConnection"));
            });

            //registering store database
            services.AddDbContext<StoreDbContext>(options =>
            {
                //local
                //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                //deployed
                options.UseSqlServer(Configuration.GetConnectionString("ProductionStoreConnection"));
            });

            //mapping; dependency injection
            services.AddTransient<IInventory, InventoryManagement>();

            //adding ApplicationUser identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            //adding use authentication AFTER useRouting            
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
