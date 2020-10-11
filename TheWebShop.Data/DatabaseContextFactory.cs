using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TheWebShop.Data
{
    /// <summary>
    /// Factory used to create <see cref="DatabaseContext"/>s .
    /// </summary>
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>, IDatabaseContextFactory
    {
        /// <summary>
        /// Create a <see cref="DatabaseContext"/> using a <see cref="DbContext"/> factory.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=TheWebShop;User Id=sa;Password=P@ssw0rd!;");
                //.EnableSensitiveDataLogging(true)
                //.UseLoggerFactory(new ServiceCollection()
                //                      .AddLogging(builder => builder.AddConsole()
                //                                      .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                //                      .BuildServiceProvider().GetService<ILoggerFactory>());

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}