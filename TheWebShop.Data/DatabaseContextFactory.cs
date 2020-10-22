using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TheWebShop.Data
{
    /// <summary>
    /// Factory used to create <see cref="DatabaseContext"/>s .
    /// </summary>
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>, IDatabaseContextFactory
    {
        private readonly IConfiguration _configuration;

        public DatabaseContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        /// <summary>
        /// Create a <see cref="DatabaseContext"/> using a <see cref="DbContext"/> factory.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            
#if (DEBUG)
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DevelopmentDatabase"));
#else
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MainDatabase"));
#endif
            
            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}