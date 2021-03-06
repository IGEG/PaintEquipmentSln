using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using PaintEquipment.Models;
using Microsoft.AspNetCore.Identity;

namespace PaintEquipment
{
    public class Startup
    {
       
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        private IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:PaintEquipmentConnection"]));
            services.AddDbContext<AppIdentityDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:IdentityConnection"]));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddScoped<IAppRepository, EFAppRepository>();
            services.AddScoped<IAppOrder, EFAppOrder>();
            services.AddScoped<IAppRequest, EFAppRequest>();
            services.AddScoped<IAppProductRequest, EFAppProductRequest>();
            services.AddScoped<IAppCategory, EFAppCategory>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddScoped<CartAll>(s => SessionCart.GetCart(s));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                


                endpoints.MapControllerRoute("Product", "Category/Product/{URLadress?}",
                    new { Controller = "Category", action = "Product" });


                endpoints.MapControllerRoute("Default", "{controller}/{action}",
                    new { Controller = "Main", action = "Index" });

                endpoints.MapDefaultControllerRoute();
              
               

            });
            //SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}