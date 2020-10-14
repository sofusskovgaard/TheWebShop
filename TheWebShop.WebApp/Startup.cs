using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheWebShop.Data;
using TheWebShop.Services.CachingServices;
using TheWebShop.Services.DataAccessServices.Brand;
using TheWebShop.Services.DataAccessServices.Category;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.DataAccessServices.Review;

namespace TheWebShop.WebApp
{
public class Startup
{
public Startup(IConfiguration configuration)
{
Configuration = configuration;
}
public IConfiguration Configuration { get; }

// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IDatabaseContextFactory, DatabaseContextFactory>();

            //services.AddDistributedRedisCache(
            //    options =>
            //    {
            //        var host = "localhost";
            //        var port = 6379;

            //        options.Configuration = $"{host}:{port}";
            //    }
            //);

            //services.AddScoped<ICachingService, CachingService>();

            // Configure data access services
            services.AddScoped<IProductDataAccessService, ProductDataAccessService>();
            services.AddScoped<ICategoryDataAccessService, CategoryDataAccessService>();
            services.AddScoped<IBrandDataAccessService, BrandDataAccessService>();
            services.AddScoped<IReviewDataAccessService, ReviewDataAccessService>();

            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
