using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Profiling.Storage;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Dtos;
using TheWebShop.Common.Maps;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Services.CachingServices;
using TheWebShop.Services.DataAccessServices.Brand;
using TheWebShop.Services.DataAccessServices.Category;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.DataAccessServices.Review;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.CategoryService;
using TheWebShop.Services.EntityServices.ProductService;

namespace TheWebShop.WebApp
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
            // AutoMapper
            services.AddAutoMapper(typeof(BaseMap));

            // Entity Framework DbContext Factory
            services.AddScoped<IDatabaseContextFactory, DatabaseContextFactory>();
            
            // MiniProfiler
            //services.AddMiniProfiler(options =>
            //{
            //    options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.VerboseSqlServerFormatter();
            //    options.EnableMvcFilterProfiling = true;
            //    options.EnableMvcViewProfiling = true;
            //}).AddEntityFramework();

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

            // Configure entity services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiniProfiler();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}