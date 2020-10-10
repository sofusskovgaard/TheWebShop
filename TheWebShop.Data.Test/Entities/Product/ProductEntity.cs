using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheWebShop.Data.Test.Entities.Product
{
    [TestClass]
    public class ProductEntity
    {
        private readonly DbContextOptions<DatabaseContext> _options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer("Server=localhost;Database=TheWebShopTest;User Id=sa;Password=P@ssw0rd;")
            .Options;
        private void SeedDatabase()
        {
            using var context = new DatabaseContext(_options);
            
            context.Add(
                new Data.Entities.Product.ProductEntity()
                {
                    Name =  "Test"
                }
            );

            context.SaveChanges();
        }
        
        [TestMethod]
        public void CREATE_PRODUCT_ENTITY()
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
                Assert.AreEqual(1, context.Products.Count());
                Assert.AreEqual("Test", context.Products.Single().Name);
            }
        }
        
        [TestMethod]
        public void READ_PRODUCT_ENTITY()
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
                Assert.AreEqual(1, context.Products.Count());
                Assert.AreEqual("Test", context.Products.Single().Name);
            }
        }
        
        [TestMethod]
        public void UPDATE_PRODUCT_ENTITY()
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
                var product = context.Products.First();

                product.Name = "Updated";

                context.SaveChanges();
            }

            // ASSERT: Use a separate instance of the context to verify correct data was saved to database
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(1, context.Products.Count());
                Assert.AreEqual("Updated", context.Products.Single().Name);
            }
        }
        
        [TestMethod]
        public void DELETE_PRODUCT_ENTITY()
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
                var product = context.Products.Single();

                context.Remove(product);
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