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
       private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:PaintEquipmentConnection"]));
            services.AddScoped<IAppRepository, EFAppRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints => {endpoints.MapDefaultControllerRoute();} );
        }
    }
}
