using System;

using Microsoft.Extensions.DependencyInjection;

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
            _serviceProvider.GetService<Application>().Run();

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