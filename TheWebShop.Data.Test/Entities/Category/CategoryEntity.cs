using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheWebShop.Data.Test.Entities.Category
{
    [TestClass]
    public class CategoryEntity
    {
        private readonly DbContextOptions<DatabaseContext> _options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer("Server=localhost;Database=TheWebShopTest;User Id=sa;Password=P@ssw0rd!;")
            .Options;
        
        private void SeedDatabase()
        {
            using var context = new DatabaseContext(_options);
            context.Add(
                new Data.Entities.Category.CategoryEntity()
                {
                    Name =  "Test"
                }
            );

            context.SaveChanges();
        }
        
        [TestMethod]
        public void CREATE_CATEGORY_ENTITY()
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
                Assert.AreEqual(1, context.Categories.Count());
                Assert.AreEqual("Test", context.Categories.Single().Name);
            }
        }
        
        [TestMethod]
        public void READ_CATEGORY_ENTITY()
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
                Assert.AreEqual(1, context.Categories.Count());
                Assert.AreEqual("Test", context.Categories.Single().Name);
            }
        }
        
        [TestMethod]
        public void UPDATE_CATEGORY_ENTITY()
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
                var entity = context.Categories.First();

                entity.Name = "Updated";

                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(1, context.Categories.Count());
                Assert.AreEqual("Updated", context.Categories.Single().Name);
            }
        }
        
        [TestMethod]
        public void DELETE_CATEGORY_ENTITY()
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
                var entity = context.Categories.Single();

                context.Remove(entity);
                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(0, context.Categories.Count());
            }
        }
    }
}