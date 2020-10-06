﻿using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using TheWebShop.Data.Entities;
using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.Category;
using TheWebShop.Data.Entities.Product;
using TheWebShop.Data.Entities.ProductCategory;
using TheWebShop.Data.Entities.ProductPicture;

namespace TheWebShop.Data
{
    public class DatabaseContext : DbContext
    {

        public DbSet<BrandEntity> BrandEntities { get; set; }
        public DbSet<CategoryEntity> CategoryEntities { get; set; }
        public DbSet<ProductEntity> ProductEntities { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategoryEntities { get; set; }
        public DbSet<ProductPictureEntity> ProductPictureEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TheWebShop;User Id=sa;Password=P@ssw0rd;")
            //.EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
            .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

#if DEBUG

            modelBuilder.SeedDatabase();

#endif

            modelBuilder.Ignore<BaseEntity>();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DatabaseContext)));
        }
    }

    public static class DatabaseContextExtensions
    {
        public static ModelBuilder SeedDatabase(this ModelBuilder modelBuilder)
        {
            #region Brands

            modelBuilder.Entity<BrandEntity>()
                .HasData(
                    new BrandEntity()
                    {
                        EntityId = 1,
                        Name = "Den gamle dame nede på havnen"
                    },
                    new BrandEntity()
                    {
                        EntityId = 2,
                        Name = "Din nabo"
                    }
                );

            #endregion

            #region Categories

            modelBuilder.Entity<CategoryEntity>()
                .HasData(
                    new CategoryEntity()
                    {
                        EntityId = 1,
                        Name = "Cannabis"
                    },
                    new CategoryEntity()
                    {
                        EntityId = 2,
                        Name = "Processeret",
                        ParentCategoryEntityId = 1
                    },
                    new CategoryEntity()
                    {
                        EntityId = 3,
                        Name = "Plante",
                        ParentCategoryEntityId = 1
                    }
                );

            #endregion

            #region Products

            modelBuilder.Entity<ProductEntity>()
                .HasData(
                    new ProductEntity()
                    {
                        EntityId = 1,
                        Name = "Lemon Haze",
                        Price = 10.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 2,
                        Name = "California Kush",
                        Price = 15.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 3,
                        Name = "Skunk",
                        Price = 5.95,
                        BrandEntityId = 2
                    }
                );

            #endregion

            #region Product Categories

            modelBuilder.Entity<ProductCategoryEntity>()
                .HasData(
                    new ProductCategoryEntity()
                    {
                        EntityId = 1,
                        ProductEntityId = 1,
                        CategoryEntityId = 1
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 2,
                        ProductEntityId = 2,
                        CategoryEntityId = 1
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 3,
                        ProductEntityId = 3,
                        CategoryEntityId = 2
                    }
                );

            #endregion

            return modelBuilder;
        }
    }
}
