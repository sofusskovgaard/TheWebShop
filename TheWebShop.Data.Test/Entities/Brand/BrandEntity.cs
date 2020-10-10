using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheWebShop.Data.Test.Entities.Brand
{
    [TestClass]
    public class BrandEntity
    {
        private readonly DbContextOptions<DatabaseContext> _options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer("Server=localhost;Database=TheWebShopTest;User Id=sa;Password=P@ssw0rd;")
            .Options;
        
        private void SeedDatabase()
        {
            using var context = new DatabaseContext(_options);
            context.Add(
                new Data.Entities.Brand.BrandEntity()
                {
                    Name =  "Test"
                }
            );

            context.SaveChanges();
        }
        
        [TestMethod]
        public void CREATE_BRAND_ENTITY()
        {
            // ARRANGE
            using (var context = new DatabaseContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // ACT
            SeedDatabase();

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(1, context.Brands.Count());
                Assert.AreEqual("Test", context.Brands.Single().Name);
            }
        }
        
        [TestMethod]
        public void READ_BRAND_ENTITY()
        {
            // ARRANGE
            using (var context = new DatabaseContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // ACT
            SeedDatabase();

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(1, context.Brands.Count());
                Assert.AreEqual("Test", context.Brands.Single().Name);
            }
        }
        
        [TestMethod]
        public void UPDATE_BRAND_ENTITY()
        {
            // ARRANGE
            using (var context = new DatabaseContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // ACT
            SeedDatabase();
            
            using (var context = new DatabaseContext(_options))
            {
                var entity = context.Brands.First();

                entity.Name = "Updated";

                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(1, context.Brands.Count());
                Assert.AreEqual("Updated", context.Brands.Single().Name);
            }
        }
        
        [TestMethod]
        public void DELETE_BRAND_ENTITY()
        {
            // ARRANGE
            using (var context = new DatabaseContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            // ACT
            SeedDatabase();
            
            using (var context = new DatabaseContext(_options))
            {
                var entity = context.Brands.Single();

                context.Remove(entity);
                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(0, context.Products.Count());
            }
        }
    }
}