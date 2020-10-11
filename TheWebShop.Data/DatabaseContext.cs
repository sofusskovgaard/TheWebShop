using Microsoft.EntityFrameworkCore;
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
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Data
{
    /// <summary>
    /// DbContext used to connect to the database.
    /// </summary>
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<ProductPictureEntity> ProductPictures { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<BaseEntity>();

#if DEBUG

            modelBuilder.SeedDatabase();

#endif

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DatabaseContext)));
        }
    }

    /// <summary>
    /// Custom extension methods for the <see cref="DatabaseContext" />
    /// </summary>
    public static class DatabaseContextExtensions
    {
        /// <summary>
        /// Seed the database using the <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public static ModelBuilder SeedDatabase(this ModelBuilder modelBuilder)
        {
            #region Brands

            modelBuilder.Entity<BrandEntity>()
                .HasData(
                    new BrandEntity()
                    {
                        EntityId = 1,
                        Name = "Big Pharma"
                    }
                );

            #endregion

            #region Categories

            modelBuilder.Entity<CategoryEntity>()
                .HasData(
                    new CategoryEntity()
                    {
                        EntityId = 1,
                        Name = "Codeine",
                        Description = "Codeine is an opiate used to treat pain, coughing, and diarrhea. It is typically used to treat mild to moderate degrees of pain. Greater benefit may occur when combined with paracetamol or a nonsteroidal anti-inflammatory drug such as aspirin or ibuprofen."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 2,
                        Name = "Fentanyl",
                        Description = "Fentanyl, also spelled fentanil, is an opioid used as a pain medication and together with other medications for anesthesia. Fentanyl is also used as a recreational drug, often mixed with heroin or cocaine. It has a rapid onset and its effects generally last less than two hours. Medically, fentanyl is used by injection, nasal spray, skin patch, or absorbed through the cheek as a lozenge or tablet."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 3,
                        Name = "Heroin",
                        Description = "Heroin, also known as diacetylmorphine and diamorphine among other names, is an opioid used as a recreational drug for its euphoric effects. Medical grade diamorphine is used as a pure hydrochloride salt which is distinguished from black tar heroin, a variable admixture of morphine derivatives—predominantly 6-MAM (6-monoacetylmorphine), which is the result of crude acetylation during clandestine production of street heroin."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 4,
                        Name = "Morphine",
                        Description = "Morphine is a pain medication of the opiate family that is found naturally in a number of plants and animals, including humans. It acts directly on the central nervous system to decrease the feeling of pain. It can be taken for both acute pain and chronic pain and is frequently used for pain from myocardial infarction and during labor."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 5,
                        Name = "Opium",
                        Description = "Opium is dried latex obtained from the seed capsules of the opium poppy Papaver somniferum. Approximately 12 percent of opium is made up of the analgesic alkaloid morphine, which is processed chemically to produce heroin and other synthetic opioids for medicinal use and for the illegal drug trade. The latex also contains the closely related opiates codeine and thebaine, and non-analgesic alkaloids such as papaverine and noscapine."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 6,
                        Name = "Oxycodone",
                        Description = "Oxycodone, sold under the brand name OxyContin among others, is an opioid medication used for treatment of moderate to severe pain, and a common drug of abuse. It is usually taken by mouth, and is available in immediate-release and controlled-release formulations. Onset of pain relief typically begins within fifteen minutes and lasts for up to six hours with the immediate-release formulation."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 7,
                        Name = "Methadone",
                        Description = "Methadone, sold under the brand names Dolophine and Methadose among others, is an opioid used for opioid maintenance therapy in opioid dependence and for chronic pain management. Detoxification using methadone can be accomplished in less than a month, or it may be done gradually over as long as six months. While a single dose has a rapid effect, maximum effect can take up to five days of use. The pain-relieving effects last about six hours after a single dose. After long-term use, in people with normal liver function, effects last 8 to 36 hours. Methadone is usually taken by mouth and rarely by injection into a muscle or vein."
                    }
                );

            #endregion

            #region Products

            modelBuilder.Entity<ProductEntity>()
                .HasData(
                    new ProductEntity()
                    {
                        EntityId = 1,
                        Name = "Fortamol",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 2,
                        Name = "Kodamid",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 3,
                        Name = "Kodipar",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 4,
                        Name = "Pinex",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 5,
                        Name = "Pure Fentanyl",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 6,
                        Name = "Contalgin",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 7,
                        Name = "Depolan",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 8,
                        Name = "Doltard",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 9,
                        Name = "Oramorph",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 10,
                        Name = "Sendolor",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 11,
                        Name = "Dropizol",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 12,
                        Name = "OxyContin",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 13,
                        Name = "Oxynorm",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 14,
                        Name = "Lindoxa",
                        Price = 9.95,
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 15,
                        Name = "Marlodon",
                        Price = 9.95,
                        BrandEntityId = 1
                    }
                );

            #endregion

            #region Reviews

            modelBuilder.Entity<ReviewEntity>()
                .HasData(
                    new ReviewEntity()
                    {
                        EntityId = 1,
                        Rating = 1,
                        Title = "Gave me titties",
                        Comment = "This horrendous got me addicted and gave me man titties. 1 star!!!1!!11!!!",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 2,
                        Rating = 5,
                        Title = "Gave me titties!",
                        Comment = "These pills gave me titties. Yay!",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 3,
                        Rating = 3,
                        Title = "Bad side effects, but great result",
                        Comment = "This product got rid of the pain but gave me severe side effects. Like waking up in a cold sweat.",
                        ProductEntityId = 1
                    }
                    //new ReviewEntity()
                    //{
                    //    EntityId = 4,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 5,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 6,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 7,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 8,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 9,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 10,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 11,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 12,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 13,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 14,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 15,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 16,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 17,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 18,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 19,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //},
                    //new ReviewEntity()
                    //{
                    //    EntityId = 20,
                    //    Rating = 5,
                    //    Title = "",
                    //    Comment = "",
                    //    ProductEntityId = 1
                    //}
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
                        CategoryEntityId = 1
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 4,
                        ProductEntityId = 4,
                        CategoryEntityId = 1
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 5,
                        ProductEntityId = 5,
                        CategoryEntityId = 2
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 6,
                        ProductEntityId = 6,
                        CategoryEntityId = 4
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 7,
                        ProductEntityId = 7,
                        CategoryEntityId = 4
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 8,
                        ProductEntityId = 8,
                        CategoryEntityId = 4
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 9,
                        ProductEntityId = 9,
                        CategoryEntityId = 4
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 10,
                        ProductEntityId = 10,
                        CategoryEntityId = 4
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 11,
                        ProductEntityId = 11,
                        CategoryEntityId = 5
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 12,
                        ProductEntityId = 12,
                        CategoryEntityId = 6
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 13,
                        ProductEntityId = 13,
                        CategoryEntityId = 6
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 14,
                        ProductEntityId = 14,
                        CategoryEntityId = 6
                    },
                    new ProductCategoryEntity()
                    {
                        EntityId = 15,
                        ProductEntityId = 15,
                        CategoryEntityId = 7
                    }
                );

            #endregion

            return modelBuilder;
        }
    }
}
