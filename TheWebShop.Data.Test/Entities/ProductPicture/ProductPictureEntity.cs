using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheWebShop.Data.Test.Entities.ProductPicture
{
    [TestClass]
    public class ProductPictureEntity
    {
        private readonly DbContextOptions<DatabaseContext> _options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseSqlServer("Server=localhost;Database=TheWebShopTest;User Id=sa;Password=P@ssw0rd;")
            .Options;
        
        private void SeedDatabase()
        {
            using (var context = new DatabaseContext(_options))
            {
                context.Add(
                    new Data.Entities.Product.ProductEntity()
                    {
                        Name =  "Test",
                        Pictures = new List<Data.Entities.ProductPicture.ProductPictureEntity>()
                        {
                            new Data.Entities.ProductPicture.ProductPictureEntity()
                            {
                                Caption = "Picture 1",
                                Picture = new [] { Byte.MinValue, Byte.MinValue,  }
                            }
                        }
                    }
                );
                
                context.SaveChanges();
            }
            
            using (var context = new DatabaseContext(_options))
            {
                var product = context.Products.Single();
                
                product.Pictures = new List<Data.Entities.ProductPicture.ProductPictureEntity>()
                {
                    new Data.Entities.ProductPicture.ProductPictureEntity()
                    {
                        Caption = "Picture 2",
                        Picture = new []{ Byte.MinValue, Byte.MaxValue }
                    },
                    new Data.Entities.ProductPicture.ProductPictureEntity()
                    {
                        Caption = "Picture 3",
                        Picture = new []{ Byte.MaxValue, Byte.MaxValue }
                    }
                };
                
                context.SaveChanges();
            }
        }
        
        [TestMethod]
        public void CREATE_PRODUCTPICTURE_ENTITY()
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
                Assert.AreEqual(3, context.ProductPictures.Count());
                Assert.AreEqual("Picture 1", context.ProductPictures.First().Caption);
            }
        }
        
        [TestMethod]
        public void READ_PRODUCTPICTURE_ENTITY()
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
                Assert.AreEqual(3, context.ProductPictures.Count());
                Assert.AreEqual("Picture 1", context.ProductPictures.First().Caption);
            }
        }
        
        [TestMethod]
        public void UPDATE_PRODUCTPICTURE_ENTITY()
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
                var entity = context.ProductPictures.First();

                entity.Caption = "Updated";

                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(3, context.ProductPictures.Count());
                Assert.AreEqual("Updated", context.ProductPictures.First().Caption);
            }
        }
        
        [TestMethod]
        public void DELETE_PRODUCTPICTURE_ENTITY()
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
                var entity = context.ProductPictures.First();

                context.Remove(entity);
                context.SaveChanges();
            }

            // ASSERT
            using (var context = new DatabaseContext(_options))
            {
                Assert.AreEqual(2, context.ProductPictures.Count());
            }
        }
    }
}