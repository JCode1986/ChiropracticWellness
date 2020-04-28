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
using Microsoft.AspNetCore.Authorization;

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
            services.AddTransient<ICartItems, CartItemsManager>();

            //adding ApplicationUser identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole(ApplicationRoles.Admin));
            });
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
/*            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }*/
            
            //app.UseRouting - this MUST ALWAYS be first
            app.UseRouting();

            
            //adding use authentication AFTER useRouting            
            app.UseStaticFiles();
            
            //Allows the use of authentication for our app
            app.UseAuthentication();
            app.UseAuthorization();

            //Seed data into db by calling RoleInitializer class
            //RoleInitializer.SeedData(serviceProvider);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
