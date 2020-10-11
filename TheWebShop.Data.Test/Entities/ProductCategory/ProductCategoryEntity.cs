using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheWebShop.Data.Entities.Category;
using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Test.Entities.ProductCategory
{
    [TestClass]
    public class ProductCategoryEntity
    {
        private readonly DbContextOptions<DatabaseContext> _options = new DbContextOptionsBuilder<DatabaseContext>()
                                 .UseSqlServer("Server=localhost;Database=TheWebShopTest;User Id=sa;Password=P@ssw0rd!;")
                                 .Options;
        private void SeedDatabase()
        {
            using (var context = new DatabaseContext(_options))
            {
                context.Add(
                    new ProductEntity()
                    {
                        Name = "Test Product"
                    }
                );

                context.Add(
                    new CategoryEntity()
                    {
                        Name = "Test Category"
                    }
                );

                context.SaveChanges();
            }
            
            using (var context = new DatabaseContext(_options))
            {
                context.Add(
                    new Data.Entities.ProductCategory.ProductCategoryEntity()
                    {
                        ProductEntityId = context.Products.Single().EntityId,
                        CategoryEntityId = context.Categories.Single().EntityId
                    }
                );

                context.SaveChanges();
            }
        }
        
        [TestMethod]
        public void CREATE_PRODUCTCATEGORY_ENTITY()
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
                Assert.AreEqual(1, context.ProductCategories.Count());
                Assert.AreEqual(1, context.Products.Count());
                Assert.AreEqual(1, context.Categories.Count());
                Assert.AreEqual("Test Product", context.ProductCategories.Include(x => x.Product).Single().Product.Name);
                Assert.AreEqual("Test Category", context.ProductCategories.Include(x => x.Category).Single().Category.Name);
            }
        }
        
        [TestMethod]
        public void READ_PRODUCTCATEGORY_ENTITY()
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
                Assert.AreEqual(1, context.ProductCategories.Count());
                Assert.AreEqual(1, context.Products.Count());
                Assert.AreEqual(1, context.Categories.Count());
                Assert.AreEqual("Test Product", context.ProductCategories.Include(x => x.Product).Single().Product.Name);
                Assert.AreEqual("Test Category", context.ProductCategories.Include(x => x.Category).Single().Category.Name);
            }
        }
        
        [TestMethod]
        public void UPDATE_PRODUCTCATEGORY_ENTITY()
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
                var entity = context.ProductCategories.First();

                entity.Product = new ProductEntity()
                {
                    Name = "New Product"
                };

                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(1, context.ProductCategories.Count());
                Assert.AreEqual(2, context.Products.Count());
                Assert.AreEqual(1, context.Categories.Count());
                Assert.AreEqual("New Product", context.ProductCategories.Include(x => x.Product).Single().Product.Name);
                Assert.AreEqual("Test Category", context.ProductCategories.Include(x => x.Category).Single().Category.Name);
            }
        }
        
        [TestMethod]
        public void DELETE_PRODUCTCATEGORY_ENTITY()
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
                var entity = context.ProductCategories.Single();

                context.Remove(entity);
                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(0, context.ProductCategories.Count());
                Assert.AreEqual(1, context.Products.Count());
                Assert.AreEqual(1, context.Categories.Count());
            }
        }
    }
}