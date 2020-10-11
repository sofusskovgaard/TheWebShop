using System;
using System.Reflection;

using AutoMapper;

using Microsoft.Extensions.DependencyInjection;

using TheWebShop.Data;
using TheWebShop.Services.CachingServices;
using TheWebShop.Services.DataAccessServices.Brand;
using TheWebShop.Services.DataAccessServices.Category;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.DataAccessServices.Review;

namespace TheWebShop.ConsoleApp
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        private static void Main(string[] args)
        {
            // Register service collection and configure injected services
            RegisterServices();

            // Start actual application
            _serviceProvider.GetService<Application>().Run().Wait();

            // Dispose of service provider
            DisposeServices();
        }

        /// <summary>
        /// Method used to configure services to be injected and register a service provider.
        /// </summary>
        private static void RegisterServices()
        {
            // Create service collection and configure our services
            var services = new ServiceCollection();

            // Configure services to inject.

            services.AddSingleton<IDatabaseContextFactory, DatabaseContextFactory>();

            services.AddDistributedRedisCache(
                options =>
                {
                    var host = "localhost";
                    var port = 6379;

                    options.Configuration = $"{host}:{port}";
                }
            );

            services.AddTransient<ICachingService, CachingService>();

            // Configure data access services
            services.AddTransient<IProductDataAccessService, ProductDataAccessService>();
            services.AddTransient<ICategoryDataAccessService, CategoryDataAccessService>();
            services.AddTransient<IBrandDataAccessService, BrandDataAccessService>();
            services.AddTransient<IReviewDataAccessService, ReviewDataAccessService>();

            services.AddSingleton<Application>();

            // Generate a service provider
            _serviceProvider = services.BuildServiceProvider(true);
        }

        /// <summary>
        /// Method used to dispose of the service provider.
        /// </summary>
        private static void DisposeServices()
        {
            // If there is no service provider there aren't any services to dispose of
            if (_serviceProvider == null) return;

            // If the service provider implements IDisposable create a variable called sp and dispose of it
            if (_serviceProvider is IDisposable sp)
            {
                sp.Dispose();
            }
        }
    }
}