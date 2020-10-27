using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using StackExchange.Redis;

using TheWebShop.Common.Maps;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Role;
using TheWebShop.Data.Entities.User;
using TheWebShop.Services.BasketService;
using TheWebShop.Services.CachingServices;
using TheWebShop.Services.DataAccessServices.Brand;
using TheWebShop.Services.DataAccessServices.Category;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.DataAccessServices.Review;
using TheWebShop.Services.EmailService;
using TheWebShop.Services.EntityServices.BrandService;
using TheWebShop.Services.EntityServices.CategoryService;
using TheWebShop.Services.EntityServices.ProductService;
using TheWebShop.Services.EntityServices.ReviewService;

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

            // Entity Framework
            services.AddDbContext<DatabaseContext>();
            services.AddScoped<IDatabaseContextFactory, DatabaseContextFactory>();

            // Identity
            services.AddIdentity<UserEntity, RoleEntity>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                })
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            // Redis
            services.AddScoped<IConnectionMultiplexer>(
                x =>
                    ConnectionMultiplexer.Connect(Configuration.GetConnectionString("DevelopmentCache"))
            );
            services.AddScoped<ICachingService, CachingService>();

            // MiniProfiler
            services.AddMiniProfiler(options =>
            {
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.VerboseSqlServerFormatter();
                options.EnableMvcFilterProfiling = true;
                options.EnableMvcViewProfiling = true;
            }).AddEntityFramework();

            // Configure data access services
            services.AddScoped<IProductDataAccessService, ProductDataAccessService>();
            services.AddScoped<ICategoryDataAccessService, CategoryDataAccessService>();
            services.AddScoped<IBrandDataAccessService, BrandDataAccessService>();
            services.AddScoped<IReviewDataAccessService, ReviewDataAccessService>();

            // Configure entity services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IReviewService, ReviewService>();
            
            // Other services
            services.AddScoped<IEmailSender, EmailService>();
            services.AddScoped<IBasketService, BasketService>();

            // Razor Pages
            services.AddRazorPages(options =>
                {
                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                })
                .AddRazorRuntimeCompilation();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Errors/403";
            });

            services.AddControllers();

            // Swagger
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Mini Profiler
            app.UseMiniProfiler();
            
            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TheWebShop v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Errors/500");
                app.UseStatusCodePagesWithReExecute("/Errors/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapControllers();
                }
            );
        }
    }
}