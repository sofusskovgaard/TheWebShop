using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TheWebShop.Data.Entities;

namespace TheWebShop.Data
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TheWebShop;Trusted_Connection=True;")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
            .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseEntity>();

            modelBuilder.ApplyConfigurations();
        }
    }

    public static class DatabaseContextExtensions
    {
        public static ModelBuilder ApplyConfigurations(this ModelBuilder modelBuilder)
        {

            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type
                   .GetInterfaces()
                   .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<BaseEntity>))
                ).ToList();

            foreach (var type in types)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            return modelBuilder;
        } 
    }
}
