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
                        Name = "Nordic Drugs",
                        Website = "https://www.nordicdrugs.dk/",
                        Email = "info@nordicdrugs.dk",
                        PhoneNumber = "+4570200840"
                    },
                    new BrandEntity()
                    {
                        EntityId = 2,
                        Name = "Takeda Pharma",
                        Website = "https://www.takeda.com/",
                        Email = "medinfoemea@takeda.com",
                        PhoneNumber = "+4546771111"
                    },
                    new BrandEntity()
                    {
                        EntityId = 3,
                        Name = "TEVA",
                        Website = "https://www.tevapharm.dk/",
                        Email = "info@tevapharm.dk",
                        PhoneNumber = "+4544985511"
                    },
                    new BrandEntity()
                    {
                        EntityId = 4,
                        Name = "Pfizer",
                        Website = "https://www.pfizer.dk/",
                        Email = "Medical.Information@pfizer.com",
                        PhoneNumber = "+4544201100"
                    },
                    new BrandEntity()
                    {
                        EntityId = 5,
                        Name = "Abcur",
                        Website = "https://www.abcur.se/",
                        Email = "info@abcur.se",
                        PhoneNumber = "+4642135770"
                    },
                    new BrandEntity()
                    {
                        EntityId = 6,
                        Name = "FrostPharma",
                        Website = "https://www.frostpharma.se/",
                        Email = "info@frostpharma.com",
                        PhoneNumber = "+4608243660"
                    },
                    new BrandEntity()
                    {
                        EntityId = 7,
                        Name = "Pharmanovia",
                        Website = "https//www.pharmanovia.com/",
                        Email = "info@pharmanovia.com",
                        PhoneNumber = "+4533337633"
                    },
                    new BrandEntity()
                    {
                        EntityId = 8,
                        Name = "Mundipharma",
                        Website = "https://mundipharma.dk/",
                        Email = "mundipharma@mundipharma.dk",
                        PhoneNumber = "+4545174800"
                    },
                    new BrandEntity()
                    {
                        EntityId = 9,
                        Name = "2care4 Generics",
                        Website = "https://www.2care4.dk/2care4-generics/",
                        Email = "info@2care4generics.dk",
                        PhoneNumber = "+4576101500"
                    },
                    new BrandEntity()
                    {
                        EntityId = 10,
                        Name = "Orifarm Generics",
                        Website = "https://www.orifarm.dk/",
                        Email = "info@orifarm.dk",
                        PhoneNumber = "+4563952700"
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
                        Description =
                            "Codeine is an opiate used to treat pain, coughing, and diarrhea. It is typically used to treat mild to moderate degrees of pain. Greater benefit may occur when combined with paracetamol or a nonsteroidal anti-inflammatory drug such as aspirin or ibuprofen."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 2,
                        Name = "Fentanyl",
                        Description =
                            "Fentanyl, also spelled fentanil, is an opioid used as a pain medication and together with other medications for anesthesia. Fentanyl is also used as a recreational drug, often mixed with heroin or cocaine. It has a rapid onset and its effects generally last less than two hours. Medically, fentanyl is used by injection, nasal spray, skin patch, or absorbed through the cheek as a lozenge or tablet."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 3,
                        Name = "Heroin",
                        Description =
                            "Heroin, also known as diacetylmorphine and diamorphine among other names, is an opioid used as a recreational drug for its euphoric effects. Medical grade diamorphine is used as a pure hydrochloride salt which is distinguished from black tar heroin, a variable admixture of morphine derivatives—predominantly 6-MAM (6-monoacetylmorphine), which is the result of crude acetylation during clandestine production of street heroin."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 4,
                        Name = "Morphine",
                        Description =
                            "Morphine is a pain medication of the opiate family that is found naturally in a number of plants and animals, including humans. It acts directly on the central nervous system to decrease the feeling of pain. It can be taken for both acute pain and chronic pain and is frequently used for pain from myocardial infarction and during labor."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 5,
                        Name = "Opium",
                        Description =
                            "Opium is dried latex obtained from the seed capsules of the opium poppy Papaver somniferum. Approximately 12 percent of opium is made up of the analgesic alkaloid morphine, which is processed chemically to produce heroin and other synthetic opioids for medicinal use and for the illegal drug trade. The latex also contains the closely related opiates codeine and thebaine, and non-analgesic alkaloids such as papaverine and noscapine."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 6,
                        Name = "Oxycodone",
                        Description =
                            "Oxycodone, sold under the brand name OxyContin among others, is an opioid medication used for treatment of moderate to severe pain, and a common drug of abuse. It is usually taken by mouth, and is available in immediate-release and controlled-release formulations. Onset of pain relief typically begins within fifteen minutes and lasts for up to six hours with the immediate-release formulation."
                    },
                    new CategoryEntity()
                    {
                        EntityId = 7,
                        Name = "Methadone",
                        Description =
                            "Methadone, sold under the brand names Dolophine and Methadose among others, is an opioid used for opioid maintenance therapy in opioid dependence and for chronic pain management. Detoxification using methadone can be accomplished in less than a month, or it may be done gradually over as long as six months. While a single dose has a rapid effect, maximum effect can take up to five days of use. The pain-relieving effects last about six hours after a single dose. After long-term use, in people with normal liver function, effects last 8 to 36 hours. Methadone is usually taken by mouth and rarely by injection into a muscle or vein."
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
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 2,
                        Name = "Kodamid",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 2
                    },
                    new ProductEntity()
                    {
                        EntityId = 3,
                        Name = "Kodipar",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 2
                    },
                    new ProductEntity()
                    {
                        EntityId = 4,
                        Name = "Pinex",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 3
                    },
                    new ProductEntity()
                    {
                        EntityId = 5,
                        Name = "Pure Fentanyl",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu."
                    },
                    new ProductEntity()
                    {
                        EntityId = 6,
                        Name = "Contalgin",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 4
                    },
                    new ProductEntity()
                    {
                        EntityId = 7,
                        Name = "Depolan",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 1
                    },
                    new ProductEntity()
                    {
                        EntityId = 8,
                        Name = "Doltard",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 2
                    },
                    new ProductEntity()
                    {
                        EntityId = 9,
                        Name = "Oramorph",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 5
                    },
                    new ProductEntity()
                    {
                        EntityId = 10,
                        Name = "Sendolor",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 6
                    },
                    new ProductEntity()
                    {
                        EntityId = 11,
                        Name = "Dropizol",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 7
                    },
                    new ProductEntity()
                    {
                        EntityId = 12,
                        Name = "OxyContin",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 8
                    },
                    new ProductEntity()
                    {
                        EntityId = 13,
                        Name = "Oxynorm",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 8
                    },
                    new ProductEntity()
                    {
                        EntityId = 14,
                        Name = "Lindoxa",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 9
                    },
                    new ProductEntity()
                    {
                        EntityId = 15,
                        Name = "Marlodon",
                        Stock = 100,
                        Price = 9.95,
                        Description =
                            "Etiam in augue tempus, vulputate odio id, varius orci. Vivamus luctus, felis ut condimentum porta, nisi nisl aliquam nunc, a convallis sapien metus vitae turpis. Morbi auctor nunc dui, non tincidunt orci pharetra vitae. Morbi vel ex et ipsum iaculis mattis. Vivamus condimentum, nisi non pellentesque dapibus, enim est tristique odio, vel condimentum dolor leo eget ante. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Aliquam quis faucibus nibh. Aliquam vitae magna fermentum, auctor erat et, condimentum sem. Mauris convallis, felis eu fermentum elementum, sem metus rutrum massa, id placerat sem erat quis nunc. Vivamus efficitur lectus a tellus facilisis scelerisque. Mauris volutpat sapien vitae nibh faucibus, cursus varius lacus efficitur. Cras vel egestas ante. Aenean auctor eu est eu sollicitudin. In viverra posuere ipsum, quis tristique felis. Sed maximus lobortis lorem dictum efficitur. Vivamus mattis risus eget ante dignissim dictum non nec arcu.",
                        BrandEntityId = 10
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
                        Comment =
                            "This product got rid of the pain but gave me severe side effects. Like waking up in a cold sweat.",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 4, Rating = 5,
                        Title = "velit in aliquet lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu",
                        Comment =
                            "arcu. Sed et libero. Proin mi. Aliquam gravida mauris ut mi. Duis risus odio, auctor vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet non, vestibulum nec, euismod",
                        ProductEntityId = 8
                    },
                    new ReviewEntity()
                    {
                        EntityId = 5, Rating = 3, Title = "molestie pharetra nibh. Aliquam ornare, libero",
                        Comment =
                            "egestas a, dui. Cras pellentesque. Sed dictum. Proin eget odio. Aliquam vulputate ullamcorper magna. Sed eu eros. Nam consequat dolor vitae dolor. Donec fringilla. Donec feugiat metus",
                        ProductEntityId = 11
                    },
                    new ReviewEntity()
                    {
                        EntityId = 6, Rating = 1,
                        Title =
                            "semper et, lacinia vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam",
                        Comment =
                            "auctor. Mauris vel turpis. Aliquam adipiscing lobortis risus. In mi pede, nonummy ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed neque. Sed eget lacus. Mauris non dui nec urna suscipit",
                        ProductEntityId = 13
                    },
                    new ReviewEntity()
                    {
                        EntityId = 7, Rating = 2, Title = "ipsum primis in faucibus orci luctus et ultrices",
                        Comment =
                            "Nullam velit dui, semper et, lacinia vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum lorem ac risus. Morbi metus. Vivamus euismod",
                        ProductEntityId = 11
                    },
                    new ReviewEntity()
                    {
                        EntityId = 8, Rating = 5, Title = "eu augue porttitor interdum. Sed auctor odio a purus.",
                        Comment =
                            "et pede. Nunc sed orci lobortis augue scelerisque mollis. Phasellus libero mauris, aliquam eu, accumsan sed, facilisis vitae, orci. Phasellus dapibus quam quis diam. Pellentesque habitant morbi tristique senectus",
                        ProductEntityId = 11
                    },
                    new ReviewEntity()
                    {
                        EntityId = 9, Rating = 1,
                        Title = "vestibulum massa rutrum magna. Cras convallis convallis dolor. Quisque tincidunt",
                        Comment =
                            "eu dui. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean eget magna. Suspendisse tristique neque venenatis lacus. Etiam bibendum fermentum metus. Aenean sed pede nec ante blandit viverra.",
                        ProductEntityId = 13
                    },
                    new ReviewEntity()
                    {
                        EntityId = 10, Rating = 5,
                        Title = "vel est tempor bibendum. Donec felis orci, adipiscing non, luctus sit",
                        Comment =
                            "nec tellus. Nunc lectus pede, ultrices a, auctor non, feugiat nec, diam. Duis mi enim, condimentum",
                        ProductEntityId = 7
                    },
                    new ReviewEntity()
                    {
                        EntityId = 11, Rating = 4,
                        Title = "nunc est, mollis non, cursus non, egestas a, dui. Cras pellentesque. Sed",
                        Comment =
                            "dapibus ligula. Aliquam erat volutpat. Nulla dignissim. Maecenas ornare egestas ligula. Nullam feugiat placerat velit. Quisque varius. Nam porttitor",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 12, Rating = 3,
                        Title = "imperdiet, erat nonummy ultricies ornare, elit elit fermentum risus, at fringilla",
                        Comment =
                            "enim mi tempor lorem, eget mollis lectus pede et risus. Quisque libero lacus, varius et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit amet luctus vulputate, nisi sem semper erat, in consectetuer ipsum nunc id enim. Curabitur massa. Vestibulum",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 13, Rating = 3, Title = "nibh sit amet orci.",
                        Comment =
                            "felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus nibh dolor, nonummy ac, feugiat non, lobortis quis, pede. Suspendisse dui. Fusce diam nunc, ullamcorper eu, euismod ac, fermentum vel, mauris.",
                        ProductEntityId = 11
                    },
                    new ReviewEntity()
                    {
                        EntityId = 14, Rating = 1,
                        Title = "velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc",
                        Comment =
                            "faucibus orci luctus et ultrices posuere cubilia Curae; Phasellus ornare. Fusce mollis. Duis sit amet diam eu dolor egestas rhoncus. Proin nisl sem, consequat nec, mollis vitae, posuere at, velit. Cras lorem lorem, luctus ut, pellentesque eget, dictum",
                        ProductEntityId = 8
                    },
                    new ReviewEntity()
                    {
                        EntityId = 15, Rating = 4,
                        Title = "non justo. Proin non massa non ante bibendum ullamcorper. Duis",
                        Comment =
                            "Cras lorem lorem, luctus ut, pellentesque eget, dictum placerat, augue. Sed molestie.",
                        ProductEntityId = 2
                    },
                    new ReviewEntity()
                    {
                        EntityId = 16, Rating = 5,
                        Title = "ante bibendum ullamcorper. Duis cursus, diam at pretium aliquet, metus urna",
                        Comment =
                            "ac sem ut dolor dapibus gravida. Aliquam tincidunt, nunc ac mattis ornare, lectus ante dictum mi, ac mattis velit justo nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non leo. Vivamus nibh dolor,",
                        ProductEntityId = 3
                    },
                    new ReviewEntity()
                    {
                        EntityId = 17, Rating = 2, Title = "Aliquam fringilla cursus purus. Nullam scelerisque",
                        Comment =
                            "Mauris blandit enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate eu, odio. Phasellus at",
                        ProductEntityId = 14
                    },
                    new ReviewEntity()
                    {
                        EntityId = 18, Rating = 3, Title = "Nam tempor diam dictum sapien. Aenean massa.",
                        Comment =
                            "purus, in molestie tortor nibh sit amet orci. Ut sagittis lobortis mauris. Suspendisse aliquet molestie tellus. Aenean egestas hendrerit neque. In ornare sagittis felis. Donec",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 19, Rating = 4,
                        Title = "orci. Donec nibh. Quisque nonummy ipsum non arcu. Vivamus sit amet",
                        Comment =
                            "neque pellentesque massa lobortis ultrices. Vivamus rhoncus. Donec est. Nunc ullamcorper, velit in aliquet lobortis, nisi nibh lacinia orci, consectetuer euismod est arcu ac orci. Ut semper pretium neque. Morbi quis urna. Nunc quis arcu vel quam dignissim pharetra. Nam",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 20, Rating = 3, Title = "lacus, varius et, euismod",
                        Comment =
                            "massa rutrum magna. Cras convallis convallis dolor. Quisque tincidunt pede ac urna. Ut tincidunt vehicula risus. Nulla eget metus eu erat semper rutrum. Fusce dolor quam, elementum at,",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 21, Rating = 2, Title = "non, hendrerit id, ante. Nunc mauris sapien, cursus",
                        Comment =
                            "lacus. Ut nec urna et arcu imperdiet ullamcorper. Duis at lacus. Quisque purus sapien, gravida non, sollicitudin a, malesuada id, erat. Etiam vestibulum massa rutrum magna.",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 22, Rating = 4, Title = "Proin eget odio. Aliquam vulputate",
                        Comment =
                            "eget nisi dictum augue malesuada malesuada. Integer id magna et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros non",
                        ProductEntityId = 3
                    },
                    new ReviewEntity()
                    {
                        EntityId = 23, Rating = 4, Title = "turpis egestas. Aliquam fringilla cursus",
                        Comment =
                            "vel lectus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a tortor. Nunc commodo auctor velit. Aliquam nisl. Nulla eu neque pellentesque",
                        ProductEntityId = 4
                    },
                    new ReviewEntity()
                    {
                        EntityId = 24, Rating = 5, Title = "amet, risus. Donec nibh enim,",
                        Comment =
                            "nec urna et arcu imperdiet ullamcorper. Duis at lacus. Quisque purus sapien, gravida non, sollicitudin a, malesuada id, erat. Etiam vestibulum massa rutrum magna. Cras convallis convallis dolor. Quisque tincidunt",
                        ProductEntityId = 13
                    },
                    new ReviewEntity()
                    {
                        EntityId = 25, Rating = 3,
                        Title = "mus. Aenean eget magna. Suspendisse tristique neque venenatis lacus.",
                        Comment =
                            "non enim commodo hendrerit. Donec porttitor tellus non magna. Nam ligula elit, pretium et,",
                        ProductEntityId = 4
                    },
                    new ReviewEntity()
                    {
                        EntityId = 26, Rating = 5, Title = "tristique pharetra. Quisque ac libero nec",
                        Comment =
                            "eu eros. Nam consequat dolor vitae dolor. Donec fringilla. Donec feugiat metus sit amet ante. Vivamus non lorem vitae odio sagittis",
                        ProductEntityId = 3
                    },
                    new ReviewEntity()
                    {
                        EntityId = 27, Rating = 1, Title = "Nulla facilisi. Sed neque. Sed eget",
                        Comment =
                            "pede ac urna. Ut tincidunt vehicula risus. Nulla eget metus eu erat semper rutrum. Fusce dolor quam, elementum at, egestas a, scelerisque sed, sapien. Nunc pulvinar arcu et",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 28, Rating = 3, Title = "est, vitae sodales nisi magna sed dui.",
                        Comment =
                            "Aliquam erat volutpat. Nulla dignissim. Maecenas ornare egestas ligula. Nullam feugiat placerat velit. Quisque varius. Nam porttitor scelerisque neque. Nullam nisl. Maecenas malesuada fringilla est. Mauris eu turpis. Nulla aliquet. Proin velit. Sed malesuada augue ut lacus. Nulla tincidunt,",
                        ProductEntityId = 4
                    },
                    new ReviewEntity()
                    {
                        EntityId = 29, Rating = 4, Title = "dolor, tempus non, lacinia at, iaculis",
                        Comment =
                            "pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem.",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 30, Rating = 3, Title = "Duis risus odio, auctor vitae,",
                        Comment =
                            "nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu nibh vulputate mauris sagittis placerat.",
                        ProductEntityId = 13
                    },
                    new ReviewEntity()
                    {
                        EntityId = 31, Rating = 4, Title = "tempus risus. Donec egestas.",
                        Comment =
                            "risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque fringilla euismod enim. Etiam gravida molestie arcu. Sed eu nibh vulputate",
                        ProductEntityId = 15
                    },
                    new ReviewEntity()
                    {
                        EntityId = 32, Rating = 4,
                        Title = "est tempor bibendum. Donec felis orci, adipiscing non, luctus sit amet,",
                        Comment =
                            "Cras eu tellus eu augue porttitor interdum. Sed auctor odio a purus. Duis elementum, dui quis accumsan convallis, ante lectus convallis",
                        ProductEntityId = 12
                    },
                    new ReviewEntity()
                    {
                        EntityId = 33, Rating = 3,
                        Title = "commodo ipsum. Suspendisse non leo. Vivamus nibh dolor, nonummy ac, feugiat",
                        Comment =
                            "non massa non ante bibendum ullamcorper. Duis cursus, diam at pretium aliquet, metus urna convallis erat, eget tincidunt dui augue eu tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus id,",
                        ProductEntityId = 13
                    },
                    new ReviewEntity()
                    {
                        EntityId = 34, Rating = 3, Title = "Nunc lectus pede, ultrices a, auctor non, feugiat nec,",
                        Comment =
                            "eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 35, Rating = 1,
                        Title = "ridiculus mus. Aenean eget magna. Suspendisse tristique neque venenatis lacus. Etiam",
                        Comment =
                            "amet, risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes,",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 36, Rating = 3, Title = "a, aliquet vel, vulputate eu,",
                        Comment =
                            "nec tellus. Nunc lectus pede, ultrices a, auctor non, feugiat nec, diam. Duis mi enim, condimentum eget, volutpat ornare, facilisis eget, ipsum. Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede. Cum sociis natoque penatibus et magnis dis parturient",
                        ProductEntityId = 12
                    },
                    new ReviewEntity()
                    {
                        EntityId = 37, Rating = 4, Title = "ipsum leo elementum sem, vitae aliquam",
                        Comment =
                            "gravida nunc sed pede. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel arcu eu odio tristique pharetra. Quisque ac libero nec ligula consectetuer rhoncus. Nullam velit dui, semper et,",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 38, Rating = 1, Title = "diam. Duis mi enim, condimentum eget,",
                        Comment =
                            "nulla. Integer urna. Vivamus molestie dapibus ligula. Aliquam erat volutpat. Nulla dignissim. Maecenas ornare egestas ligula. Nullam feugiat placerat velit. Quisque varius. Nam porttitor scelerisque neque. Nullam nisl. Maecenas malesuada fringilla est. Mauris eu turpis. Nulla aliquet. Proin velit. Sed malesuada augue ut",
                        ProductEntityId = 5
                    },
                    new ReviewEntity()
                    {
                        EntityId = 39, Rating = 3,
                        Title = "augue, eu tempor erat neque non quam. Pellentesque habitant",
                        Comment =
                            "Quisque tincidunt pede ac urna. Ut tincidunt vehicula risus. Nulla eget metus eu erat semper rutrum. Fusce dolor quam, elementum at, egestas a, scelerisque sed, sapien. Nunc pulvinar arcu et pede. Nunc sed orci",
                        ProductEntityId = 6
                    },
                    new ReviewEntity()
                    {
                        EntityId = 40, Rating = 3, Title = "ante ipsum primis in faucibus orci luctus et",
                        Comment =
                            "scelerisque dui. Suspendisse ac metus vitae velit egestas lacinia. Sed congue, elit sed consequat auctor, nunc nulla vulputate dui, nec tempus mauris erat eget ipsum. Suspendisse sagittis. Nullam vitae diam. Proin dolor. Nulla semper tellus id nunc interdum feugiat. Sed nec",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 41, Rating = 2,
                        Title = "non, cursus non, egestas a, dui. Cras pellentesque. Sed dictum. Proin",
                        Comment =
                            "vehicula risus. Nulla eget metus eu erat semper rutrum. Fusce dolor quam, elementum at, egestas a, scelerisque sed, sapien. Nunc pulvinar arcu et pede. Nunc",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 42, Rating = 2, Title = "tellus faucibus leo, in lobortis tellus justo sit",
                        Comment =
                            "sed tortor. Integer aliquam adipiscing lacus. Ut nec urna et arcu imperdiet ullamcorper. Duis at lacus. Quisque purus sapien, gravida non, sollicitudin a, malesuada id, erat. Etiam vestibulum massa rutrum magna.",
                        ProductEntityId = 3
                    },
                    new ReviewEntity()
                    {
                        EntityId = 43, Rating = 5,
                        Title =
                            "justo nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate,",
                        Comment =
                            "non dui nec urna suscipit nonummy. Fusce fermentum fermentum arcu. Vestibulum ante ipsum",
                        ProductEntityId = 6
                    },
                    new ReviewEntity()
                    {
                        EntityId = 44, Rating = 2, Title = "dictum eu, placerat eget, venenatis a,",
                        Comment =
                            "nec metus facilisis lorem tristique aliquet. Phasellus fermentum convallis ligula. Donec luctus aliquet odio. Etiam ligula tortor, dictum eu, placerat eget, venenatis a, magna. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Etiam laoreet, libero et tristique pellentesque, tellus sem mollis dui, in sodales elit erat",
                        ProductEntityId = 8
                    },
                    new ReviewEntity()
                    {
                        EntityId = 45, Rating = 5, Title = "elit. Nulla facilisi. Sed neque. Sed eget lacus.",
                        Comment =
                            "cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis in, cursus et, eros. Proin ultrices. Duis volutpat nunc sit amet metus. Aliquam erat volutpat. Nulla facilisis. Suspendisse commodo tincidunt nibh. Phasellus nulla. Integer vulputate, risus a ultricies",
                        ProductEntityId = 14
                    },
                    new ReviewEntity()
                    {
                        EntityId = 46, Rating = 2, Title = "ac sem ut dolor dapibus gravida. Aliquam",
                        Comment =
                            "nunc est, mollis non, cursus non, egestas a, dui. Cras pellentesque. Sed dictum. Proin eget odio. Aliquam vulputate ullamcorper magna. Sed eu eros. Nam consequat dolor vitae dolor. Donec fringilla. Donec feugiat metus sit amet ante. Vivamus non lorem vitae odio sagittis semper. Nam tempor",
                        ProductEntityId = 7
                    },
                    new ReviewEntity()
                    {
                        EntityId = 47, Rating = 1, Title = "urna suscipit nonummy. Fusce fermentum",
                        Comment =
                            "semper, dui lectus rutrum urna, nec luctus felis purus ac tellus. Suspendisse sed dolor. Fusce mi lorem, vehicula et, rutrum eu, ultrices sit amet, risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 48, Rating = 4,
                        Title = "lacus. Quisque purus sapien, gravida non, sollicitudin a, malesuada id, erat.",
                        Comment =
                            "rhoncus. Nullam velit dui, semper et, lacinia vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum lorem ac risus. Morbi metus. Vivamus euismod urna. Nullam lobortis quam a felis ullamcorper viverra. Maecenas iaculis aliquet diam. Sed diam lorem, auctor quis, tristique ac, eleifend vitae, erat. Vivamus nisi.",
                        ProductEntityId = 6
                    },
                    new ReviewEntity()
                    {
                        EntityId = 49, Rating = 5, Title = "ut, pharetra sed, hendrerit a,",
                        Comment =
                            "id nunc interdum feugiat. Sed nec metus facilisis lorem tristique aliquet. Phasellus fermentum convallis ligula. Donec luctus aliquet odio. Etiam ligula tortor, dictum eu, placerat",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 50, Rating = 5, Title = "molestie arcu. Sed eu nibh vulputate",
                        Comment =
                            "ante dictum mi, ac mattis velit justo nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo",
                        ProductEntityId = 7
                    },
                    new ReviewEntity()
                    {
                        EntityId = 51, Rating = 4, Title = "Donec feugiat metus sit amet ante. Vivamus non lorem",
                        Comment =
                            "fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis",
                        ProductEntityId = 3
                    },
                    new ReviewEntity()
                    {
                        EntityId = 52, Rating = 1,
                        Title = "elit erat vitae risus. Duis a mi fringilla mi lacinia mattis.",
                        Comment =
                            "lacus. Etiam bibendum fermentum metus. Aenean sed pede nec ante blandit viverra. Donec tempus, lorem fringilla ornare placerat, orci",
                        ProductEntityId = 14
                    },
                    new ReviewEntity()
                    {
                        EntityId = 53, Rating = 3, Title = "aliquet vel, vulputate eu, odio. Phasellus",
                        Comment =
                            "sed libero. Proin sed turpis nec mauris blandit mattis. Cras eget nisi dictum augue malesuada malesuada. Integer id magna et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros non enim commodo hendrerit.",
                        ProductEntityId = 7
                    },
                    new ReviewEntity()
                    {
                        EntityId = 54, Rating = 4,
                        Title = "sed libero. Proin sed turpis nec mauris blandit mattis. Cras eget nisi",
                        Comment =
                            "magna. Duis dignissim tempor arcu. Vestibulum ut eros non enim commodo hendrerit. Donec porttitor tellus non magna. Nam ligula elit, pretium et, rutrum non, hendrerit id, ante. Nunc mauris sapien, cursus in, hendrerit consectetuer, cursus et, magna. Praesent interdum ligula eu",
                        ProductEntityId = 2
                    },
                    new ReviewEntity()
                    {
                        EntityId = 55, Rating = 5, Title = "sed pede. Cum sociis",
                        Comment =
                            "justo eu arcu. Morbi sit amet massa. Quisque porttitor eros nec tellus. Nunc lectus pede, ultrices a, auctor non, feugiat nec, diam. Duis mi enim, condimentum eget, volutpat ornare, facilisis eget, ipsum. Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede. Cum sociis natoque penatibus et magnis",
                        ProductEntityId = 13
                    },
                    new ReviewEntity()
                    {
                        EntityId = 56, Rating = 2,
                        Title = "enim commodo hendrerit. Donec porttitor tellus non magna. Nam ligula elit, pretium",
                        Comment =
                            "ultrices posuere cubilia Curae; Phasellus ornare. Fusce mollis. Duis sit amet diam eu dolor egestas rhoncus. Proin nisl sem, consequat nec, mollis vitae, posuere at, velit. Cras lorem lorem, luctus ut, pellentesque eget, dictum placerat, augue. Sed molestie.",
                        ProductEntityId = 4
                    },
                    new ReviewEntity()
                    {
                        EntityId = 57, Rating = 1,
                        Title = "Curabitur consequat, lectus sit amet luctus vulputate, nisi sem",
                        Comment =
                            "Nullam feugiat placerat velit. Quisque varius. Nam porttitor scelerisque neque. Nullam nisl. Maecenas malesuada fringilla est. Mauris eu turpis. Nulla aliquet. Proin velit. Sed malesuada augue ut lacus. Nulla tincidunt, neque vitae semper egestas, urna justo faucibus lectus, a sollicitudin orci sem eget massa. Suspendisse eleifend. Cras sed",
                        ProductEntityId = 15
                    },
                    new ReviewEntity()
                    {
                        EntityId = 58, Rating = 5, Title = "dui lectus rutrum urna, nec luctus felis purus",
                        Comment =
                            "eleifend egestas. Sed pharetra, felis eget varius ultrices, mauris ipsum porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque non quam. Pellentesque habitant morbi tristique senectus et",
                        ProductEntityId = 4
                    },
                    new ReviewEntity()
                    {
                        EntityId = 59, Rating = 1,
                        Title =
                            "Mauris molestie pharetra nibh. Aliquam ornare, libero at auctor ullamcorper, nisl arcu",
                        Comment =
                            "Quisque ornare tortor at risus. Nunc ac sem ut dolor dapibus gravida. Aliquam tincidunt, nunc ac mattis ornare, lectus ante dictum mi, ac mattis velit justo nec ante. Maecenas mi felis, adipiscing fringilla, porttitor vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 60, Rating = 2,
                        Title = "sapien. Aenean massa. Integer vitae nibh. Donec est mauris, rhoncus id, mollis",
                        Comment =
                            "malesuada malesuada. Integer id magna et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros non enim commodo hendrerit. Donec porttitor tellus",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 61, Rating = 3, Title = "lectus quis massa. Mauris vestibulum, neque sed dictum",
                        Comment =
                            "erat, eget tincidunt dui augue eu tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus non, lacinia at, iaculis quis, pede. Praesent",
                        ProductEntityId = 5
                    },
                    new ReviewEntity()
                    {
                        EntityId = 62, Rating = 1, Title = "libero. Proin sed turpis nec mauris blandit",
                        Comment =
                            "a, enim. Suspendisse aliquet, sem ut cursus luctus, ipsum leo elementum sem, vitae aliquam eros turpis non enim. Mauris quis turpis vitae purus gravida sagittis. Duis gravida. Praesent eu",
                        ProductEntityId = 2
                    },
                    new ReviewEntity()
                    {
                        EntityId = 63, Rating = 3, Title = "dui. Fusce diam nunc,",
                        Comment =
                            "ac tellus. Suspendisse sed dolor. Fusce mi lorem, vehicula et, rutrum eu, ultrices sit amet, risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin",
                        ProductEntityId = 13
                    },
                    new ReviewEntity()
                    {
                        EntityId = 64, Rating = 3, Title = "dictum mi, ac mattis",
                        Comment =
                            "Phasellus libero mauris, aliquam eu, accumsan sed, facilisis vitae, orci. Phasellus dapibus quam quis diam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac",
                        ProductEntityId = 15
                    },
                    new ReviewEntity()
                    {
                        EntityId = 65, Rating = 3,
                        Title =
                            "mauris. Suspendisse aliquet molestie tellus. Aenean egestas hendrerit neque. In ornare sagittis",
                        Comment =
                            "in molestie tortor nibh sit amet orci. Ut sagittis lobortis mauris. Suspendisse aliquet molestie tellus. Aenean egestas hendrerit neque. In ornare sagittis felis. Donec tempor, est ac mattis semper, dui lectus rutrum urna,",
                        ProductEntityId = 5
                    },
                    new ReviewEntity()
                    {
                        EntityId = 66, Rating = 1, Title = "nascetur ridiculus mus. Aenean eget",
                        Comment =
                            "velit. Sed malesuada augue ut lacus. Nulla tincidunt, neque vitae semper egestas, urna justo faucibus lectus, a sollicitudin orci sem eget massa. Suspendisse eleifend. Cras sed leo. Cras vehicula aliquet libero. Integer in magna. Phasellus dolor elit, pellentesque a,",
                        ProductEntityId = 6
                    },
                    new ReviewEntity()
                    {
                        EntityId = 67, Rating = 2, Title = "non arcu. Vivamus sit amet risus. Donec",
                        Comment =
                            "ad litora torquent per conubia nostra, per inceptos hymenaeos. Mauris ut quam vel sapien imperdiet ornare. In",
                        ProductEntityId = 8
                    },
                    new ReviewEntity()
                    {
                        EntityId = 68, Rating = 3,
                        Title = "Maecenas iaculis aliquet diam. Sed diam lorem, auctor quis, tristique ac, eleifend",
                        Comment =
                            "nisi a odio semper cursus. Integer mollis. Integer tincidunt aliquam arcu. Aliquam ultrices iaculis odio. Nam interdum enim non nisi. Aenean eget metus.",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 69, Rating = 5,
                        Title = "Fusce diam nunc, ullamcorper eu, euismod ac, fermentum vel,",
                        Comment =
                            "nec tempus scelerisque, lorem ipsum sodales purus, in molestie tortor nibh sit amet orci. Ut sagittis",
                        ProductEntityId = 12
                    },
                    new ReviewEntity()
                    {
                        EntityId = 70, Rating = 3,
                        Title = "Phasellus fermentum convallis ligula. Donec luctus aliquet odio. Etiam ligula tortor,",
                        Comment =
                            "tempor lorem, eget mollis lectus pede et risus. Quisque libero lacus, varius et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit amet luctus vulputate, nisi sem semper",
                        ProductEntityId = 14
                    },
                    new ReviewEntity()
                    {
                        EntityId = 71, Rating = 2,
                        Title = "eget, volutpat ornare, facilisis eget, ipsum. Donec sollicitudin",
                        Comment =
                            "eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer urna. Vivamus molestie dapibus ligula. Aliquam erat volutpat. Nulla dignissim.",
                        ProductEntityId = 14
                    },
                    new ReviewEntity()
                    {
                        EntityId = 72, Rating = 5,
                        Title = "Donec felis orci, adipiscing non, luctus sit amet, faucibus",
                        Comment =
                            "lorem fringilla ornare placerat, orci lacus vestibulum lorem, sit amet ultricies sem magna nec quam. Curabitur vel lectus. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a tortor. Nunc commodo auctor velit.",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 73, Rating = 1, Title = "a, facilisis non, bibendum sed, est. Nunc laoreet",
                        Comment =
                            "vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac arcu. Nunc mauris. Morbi non sapien molestie orci tincidunt adipiscing. Mauris molestie pharetra nibh. Aliquam ornare, libero at auctor ullamcorper, nisl arcu iaculis",
                        ProductEntityId = 6
                    },
                    new ReviewEntity()
                    {
                        EntityId = 74, Rating = 2, Title = "magna. Sed eu eros. Nam consequat",
                        Comment =
                            "imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac arcu. Nunc mauris. Morbi non sapien molestie orci tincidunt adipiscing. Mauris molestie",
                        ProductEntityId = 3
                    },
                    new ReviewEntity()
                    {
                        EntityId = 75, Rating = 4,
                        Title =
                            "vulputate, posuere vulputate, lacus. Cras interdum. Nunc sollicitudin commodo ipsum. Suspendisse non",
                        Comment =
                            "adipiscing non, luctus sit amet, faucibus ut, nulla. Cras eu tellus eu augue porttitor interdum. Sed",
                        ProductEntityId = 15
                    },
                    new ReviewEntity()
                    {
                        EntityId = 76, Rating = 1,
                        Title = "porttitor vulputate, posuere vulputate, lacus. Cras interdum.",
                        Comment =
                            "dui, semper et, lacinia vitae, sodales at, velit. Pellentesque ultricies dignissim lacus. Aliquam rutrum lorem ac risus. Morbi metus. Vivamus euismod urna. Nullam lobortis quam a felis ullamcorper viverra. Maecenas iaculis aliquet diam. Sed diam lorem, auctor quis,",
                        ProductEntityId = 4
                    },
                    new ReviewEntity()
                    {
                        EntityId = 77, Rating = 5, Title = "at auctor ullamcorper, nisl arcu iaculis",
                        Comment =
                            "mi pede, nonummy ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed neque. Sed eget lacus. Mauris non dui nec urna suscipit nonummy.",
                        ProductEntityId = 5
                    },
                    new ReviewEntity()
                    {
                        EntityId = 78, Rating = 4, Title = "In faucibus. Morbi vehicula. Pellentesque tincidunt",
                        Comment =
                            "tellus non magna. Nam ligula elit, pretium et, rutrum non, hendrerit id, ante. Nunc mauris sapien, cursus in, hendrerit consectetuer, cursus et, magna. Praesent",
                        ProductEntityId = 7
                    },
                    new ReviewEntity()
                    {
                        EntityId = 79, Rating = 2,
                        Title = "ornare, elit elit fermentum risus, at fringilla purus mauris a nunc. In",
                        Comment =
                            "vitae, orci. Phasellus dapibus quam quis diam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce aliquet magna a neque. Nullam ut nisi",
                        ProductEntityId = 5
                    },
                    new ReviewEntity()
                    {
                        EntityId = 80, Rating = 2,
                        Title = "et tristique pellentesque, tellus sem mollis dui, in sodales",
                        Comment =
                            "neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis in, cursus et, eros. Proin ultrices. Duis volutpat nunc sit amet metus. Aliquam erat volutpat. Nulla facilisis. Suspendisse commodo tincidunt nibh. Phasellus nulla.",
                        ProductEntityId = 15
                    },
                    new ReviewEntity()
                    {
                        EntityId = 81, Rating = 5, Title = "egestas a, scelerisque sed, sapien. Nunc pulvinar arcu",
                        Comment =
                            "Maecenas ornare egestas ligula. Nullam feugiat placerat velit. Quisque varius. Nam porttitor scelerisque neque. Nullam nisl. Maecenas malesuada fringilla est. Mauris eu turpis. Nulla aliquet. Proin velit. Sed malesuada augue",
                        ProductEntityId = 8
                    },
                    new ReviewEntity()
                    {
                        EntityId = 82, Rating = 5,
                        Title = "Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum",
                        Comment =
                            "arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec tincidunt. Donec vitae erat vel pede blandit congue. In scelerisque scelerisque dui. Suspendisse ac metus vitae velit egestas lacinia.",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 83, Rating = 5, Title = "lectus sit amet luctus",
                        Comment =
                            "erat. Sed nunc est, mollis non, cursus non, egestas a, dui. Cras pellentesque. Sed dictum. Proin eget odio. Aliquam vulputate ullamcorper magna. Sed eu eros. Nam consequat dolor vitae dolor. Donec fringilla. Donec",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 84, Rating = 4, Title = "Phasellus in felis. Nulla tempor augue ac",
                        Comment =
                            "morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce aliquet magna a neque. Nullam ut nisi a odio semper cursus. Integer mollis. Integer tincidunt aliquam arcu. Aliquam ultrices iaculis",
                        ProductEntityId = 8
                    },
                    new ReviewEntity()
                    {
                        EntityId = 85, Rating = 3, Title = "nisi. Aenean eget metus. In nec",
                        Comment =
                            "dis parturient montes, nascetur ridiculus mus. Donec dignissim magna a tortor. Nunc commodo auctor velit. Aliquam nisl. Nulla eu neque pellentesque",
                        ProductEntityId = 14
                    },
                    new ReviewEntity()
                    {
                        EntityId = 86, Rating = 2, Title = "mauris ut mi. Duis risus odio, auctor vitae, aliquet",
                        Comment =
                            "pede et risus. Quisque libero lacus, varius et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit amet",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 87, Rating = 3, Title = "eleifend non, dapibus rutrum,",
                        Comment =
                            "erat neque non quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 88, Rating = 5, Title = "Donec est. Nunc ullamcorper, velit in aliquet",
                        Comment =
                            "eget massa. Suspendisse eleifend. Cras sed leo. Cras vehicula aliquet libero. Integer in magna. Phasellus dolor elit, pellentesque a, facilisis non, bibendum sed, est. Nunc laoreet lectus quis massa. Mauris vestibulum, neque sed dictum eleifend, nunc risus varius orci, in consequat enim diam vel arcu. Curabitur ut",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 89, Rating = 3, Title = "cursus non, egestas a,",
                        Comment =
                            "pharetra ut, pharetra sed, hendrerit a, arcu. Sed et libero. Proin mi. Aliquam gravida mauris ut mi. Duis risus odio, auctor vitae, aliquet nec, imperdiet nec, leo. Morbi neque tellus, imperdiet non, vestibulum nec, euismod in, dolor. Fusce feugiat. Lorem",
                        ProductEntityId = 6
                    },
                    new ReviewEntity()
                    {
                        EntityId = 90, Rating = 4, Title = "iaculis odio. Nam interdum",
                        Comment =
                            "et netus et malesuada fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna, malesuada vel, convallis in, cursus et, eros. Proin ultrices. Duis volutpat nunc sit amet metus. Aliquam",
                        ProductEntityId = 2
                    },
                    new ReviewEntity()
                    {
                        EntityId = 91, Rating = 1, Title = "dolor sit amet, consectetuer adipiscing elit. Etiam",
                        Comment =
                            "nonummy. Fusce fermentum fermentum arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Phasellus ornare.",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 92, Rating = 4,
                        Title = "tincidunt tempus risus. Donec egestas. Duis ac arcu. Nunc mauris.",
                        Comment =
                            "eget massa. Suspendisse eleifend. Cras sed leo. Cras vehicula aliquet libero. Integer in magna. Phasellus dolor elit, pellentesque a, facilisis non, bibendum sed, est. Nunc laoreet lectus quis massa. Mauris vestibulum, neque sed dictum eleifend, nunc risus varius orci, in consequat enim diam",
                        ProductEntityId = 7
                    },
                    new ReviewEntity()
                    {
                        EntityId = 93, Rating = 1, Title = "felis. Nulla tempor augue",
                        Comment =
                            "commodo ipsum. Suspendisse non leo. Vivamus nibh dolor, nonummy ac, feugiat non, lobortis quis, pede. Suspendisse",
                        ProductEntityId = 6
                    },
                    new ReviewEntity()
                    {
                        EntityId = 94, Rating = 5,
                        Title = "ut, molestie in, tempus eu, ligula. Aenean euismod mauris eu elit.",
                        Comment =
                            "Praesent luctus. Curabitur egestas nunc sed libero. Proin sed turpis nec mauris blandit mattis. Cras eget nisi dictum augue malesuada malesuada. Integer id magna et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros non enim commodo hendrerit. Donec porttitor tellus non",
                        ProductEntityId = 10
                    },
                    new ReviewEntity()
                    {
                        EntityId = 95, Rating = 3,
                        Title = "ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor",
                        Comment =
                            "sem molestie sodales. Mauris blandit enim consequat purus. Maecenas libero est, congue a, aliquet vel, vulputate eu, odio. Phasellus at augue id ante dictum cursus. Nunc mauris elit, dictum eu,",
                        ProductEntityId = 12
                    },
                    new ReviewEntity()
                    {
                        EntityId = 96, Rating = 4, Title = "arcu ac orci. Ut semper pretium",
                        Comment =
                            "risus quis diam luctus lobortis. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Mauris ut quam vel sapien imperdiet ornare. In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis",
                        ProductEntityId = 5
                    },
                    new ReviewEntity()
                    {
                        EntityId = 97, Rating = 5,
                        Title =
                            "In faucibus. Morbi vehicula. Pellentesque tincidunt tempus risus. Donec egestas. Duis ac",
                        Comment =
                            "tempus eu, ligula. Aenean euismod mauris eu elit. Nulla facilisi. Sed neque. Sed eget lacus. Mauris non dui nec urna suscipit nonummy. Fusce fermentum fermentum arcu. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Phasellus ornare. Fusce mollis. Duis sit",
                        ProductEntityId = 12
                    },
                    new ReviewEntity()
                    {
                        EntityId = 98, Rating = 1, Title = "sed, hendrerit a, arcu. Sed et libero. Proin mi.",
                        Comment =
                            "mauris blandit mattis. Cras eget nisi dictum augue malesuada malesuada. Integer id magna et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor arcu. Vestibulum ut eros",
                        ProductEntityId = 8
                    },
                    new ReviewEntity()
                    {
                        EntityId = 99, Rating = 5,
                        Title = "quam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac",
                        Comment =
                            "nisi sem semper erat, in consectetuer ipsum nunc id enim. Curabitur massa. Vestibulum accumsan neque et nunc. Quisque ornare tortor at risus. Nunc ac sem ut dolor dapibus gravida. Aliquam tincidunt, nunc ac mattis ornare, lectus ante dictum mi, ac mattis velit justo nec ante. Maecenas",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 100, Rating = 4,
                        Title = "elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum,",
                        Comment =
                            "Aliquam erat volutpat. Nulla facilisis. Suspendisse commodo tincidunt nibh. Phasellus nulla. Integer vulputate, risus a ultricies adipiscing, enim mi tempor lorem, eget mollis lectus pede et risus. Quisque libero lacus, varius et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur",
                        ProductEntityId = 1
                    },
                    new ReviewEntity()
                    {
                        EntityId = 101, Rating = 3,
                        Title = "Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede. Cum sociis",
                        Comment =
                            "varius et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit amet luctus vulputate, nisi sem semper erat, in consectetuer ipsum nunc id enim. Curabitur massa. Vestibulum accumsan neque et",
                        ProductEntityId = 15
                    },
                    new ReviewEntity()
                    {
                        EntityId = 102, Rating = 3,
                        Title = "Aliquam fringilla cursus purus. Nullam scelerisque neque sed sem egestas blandit.",
                        Comment =
                            "urna convallis erat, eget tincidunt dui augue eu tellus. Phasellus elit pede, malesuada vel, venenatis vel, faucibus id, libero. Donec consectetuer mauris id sapien. Cras dolor dolor, tempus non,",
                        ProductEntityId = 9
                    },
                    new ReviewEntity()
                    {
                        EntityId = 103, Rating = 2, Title = "Duis a mi fringilla mi lacinia mattis. Integer eu",
                        Comment =
                            "Integer vulputate, risus a ultricies adipiscing, enim mi tempor lorem, eget mollis lectus pede et risus. Quisque libero lacus, varius et, euismod et, commodo at, libero. Morbi accumsan laoreet ipsum. Curabitur consequat, lectus sit amet luctus vulputate, nisi",
                        ProductEntityId = 3
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