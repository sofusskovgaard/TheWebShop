using Microsoft.EntityFrameworkCore;
using System;

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
        }
    }
}
