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
            services.AddScoped<IAppRepository, EFAppRepository>();
            services.AddScoped<IAppOrder, EFAppOrder>();
            services.AddRazorPages();
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
            app.UseEndpoints(endpoints => {
                
                endpoints.MapControllerRoute("catpage",
                    "{category}/Page{numerPage:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page", "Page{numerPage:int}",
                    new { Controller = "Home", action = "Index", numerPage = 1 });

                endpoints.MapControllerRoute("category", "{category}",
                    new { Controller = "Home", action = "Index", numerPage = 1 });

                endpoints.MapControllerRoute("pagination",
                    "Products/Page{numerPage}",
                    new { Controller = "Home", action = "Index", numerPage = 1 });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();

            });
            SeedData.EnsurePopulated(app);
        }
    }
}