using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheWebShop.Data.Test.Entities.Review
{
    [TestClass]
    public class ReviewEntity
    {
        private readonly DbContextOptions<DatabaseContext> _options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer("Server=localhost;Database=TheWebShopTest;User Id=sa;Password=P@ssw0rd!;")
            .Options;
        
        private void SeedDatabase()
        {
            using (var context = new DatabaseContext(_options))
            {
                context.Add(
                    new Data.Entities.Product.ProductEntity()
                    {
                        Name =  "Test",
                        Reviews = new List<Data.Entities.Review.ReviewEntity>()
                        {
                            new Data.Entities.Review.ReviewEntity()
                            {
                                Title = "Review 1",
                                Comment = "Lorem ipsum dolor sit amet.",
                                Rating = 5
                            }
                        }
                    }
                );
                
                context.SaveChanges();
            }
            
            using (var context = new DatabaseContext(_options))
            {
                var product = context.Products.Single();
                
                product.Reviews = new List<Data.Entities.Review.ReviewEntity>()
                {
                    new Data.Entities.Review.ReviewEntity()
                    {
                        Title = "Review 2",
                        Comment = "Lorem ipsum dolor sit amet.",
                        Rating = 1
                    }
                };
                
                context.SaveChanges();
            }
        }
        
        [TestMethod]
        public void CREATE_REVIEW_ENTITY()
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
                Assert.AreEqual(2, context.Reviews.Count());
                Assert.AreEqual("Review 1", context.Reviews.First().Title);
                Assert.AreEqual(1, context.Products.Count());
            }
        }
        
        [TestMethod]
        public void READ_REVIEW_ENTITY()
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
                Assert.AreEqual(2, context.Reviews.Count());
                Assert.AreEqual("Review 1", context.Reviews.First().Title);
                Assert.AreEqual(1, context.Products.Count());
            }
        }
        
        [TestMethod]
        public void UPDATE_REVIEW_ENTITY()
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
                var entity = context.Reviews.First();

                entity.Title = "Updated";

                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(2, context.Reviews.Count());
                Assert.AreEqual("Updated", context.Reviews.First().Title);
                Assert.AreEqual(1, context.Products.Count());
            }
        }
        
        [TestMethod]
        public void DELETE_REVIEW_ENTITY()
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
                var entity = context.Reviews.First();

                context.Remove(entity);
                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(1, context.Reviews.Count());
                Assert.AreEqual("Review 2", context.Reviews.First().Title);
                Assert.AreEqual(1, context.Products.Count());
            }
        }
    }
}