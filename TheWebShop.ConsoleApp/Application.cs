using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BetterConsoleTables;

using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Filters.Review;
using TheWebShop.Data;
using TheWebShop.Data.Entities.Brand;
using TheWebShop.Services.DataAccessServices.Brand;
using TheWebShop.Services.DataAccessServices.Category;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.DataAccessServices.Review;

namespace TheWebShop.ConsoleApp
{
    class Application
    {

        private readonly IProductDataAccessService _productDataAccessService;

        private readonly IBrandDataAccessService _brandDataAccessService;

        private readonly IReviewDataAccessService _reviewDataAccessService;

        private readonly ICategoryDataAccessService _categoryDataAccessService;

        private readonly DatabaseContext _context;

        public Application(
            IProductDataAccessService productDataAccessService,
            IBrandDataAccessService brandDataAccessService,
            IReviewDataAccessService reviewDataAccessService,
            ICategoryDataAccessService categoryDataAccessService,
            IDatabaseContextFactory databaseContextFactory)
        {
            _context = databaseContextFactory.CreateDbContext(null);
            _productDataAccessService = productDataAccessService;
            _brandDataAccessService = brandDataAccessService;
            _reviewDataAccessService = reviewDataAccessService;
            _categoryDataAccessService = categoryDataAccessService;
        }

        public async Task Run()
        {

#if DEBUG

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

#endif

            Console.WriteLine("i sell drugs");


            // Products

            await GetProductById(1);

            //await GetProducts();
            //await GetProductsAndOrderByNameAscending();
            //await GetProductsAndOrderByNameDescending();
            //await GetProductsAndOrderByPriceAscending();
            //await GetProductsAndOrderByPriceDescending();
            //await GetProductsAndOrderByReviewsAscending();
            //await GetProductsAndOrderByReviewsDescending();
            //await GetProductsByCategoryId(1);
            //await GetProductsBySearchText("Fort");
            //await GetProductsByFilter(new ProductFilter()
            //{
            //    OrderBy = ProductOrderBy.NameDesc
            //});

            // Brands

            //await CreateBrand();

            //await GetBrands();
            //await GetBrandsAndOrderByNameAscending();
            //await GetBrandsAndOrderByNameDescending();
            //await GetBrandsAndOrderByProductsAscending();
            //await GetBrandsAndOrderByProductsDescending();
            //await GetBrandsBySearchText("Pharma");
            //await GetBrandsByFilter(new BrandFilter()
            //{
            //    OrderBy = BrandOrderBy.NameDesc
            //});

            // Reviews

            //await GetReviews();
            //await GetReviewsAndOrderByRatingAscending();
            //await GetReviewsAndOrderByRatingDescending();
            //await GetReviewsBySearchText("");
            //await GetReviewsByProductId(1);
            //await GetReviewsByFilter(new ReviewFilter()
            //{
            //    OrderBy = ReviewOrderBy.RatingAsc
            //});

            // Categories

            //await GetCategories();
            //await GetCategoriesAndOrderByNameAscending();
            //await GetCategoriesAndOrderByNameDescending();
            //await GetCategoriesAndOrderByProductsAscending();
            //await GetCategoriesAndOrderByProductsDescending();
            //await GetCategoriesBySearch("");
            //await GetCategoriesByFilter(new CategoryFilter()
            //{
            //    OrderBy = CategoryOrderBy.NameAsc
            //});
        }

        #region Products

        public async Task GetProductById(int entityId)
        {
            var entity = await _productDataAccessService.GetById(entityId);

            #region Irrelevant

            if (entity == null)
            {
                Console.WriteLine("No Product with that ID");
            }
            else
            {
                Console.WriteLine("GetProductById");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "Property", "Value");

                foreach (var property in entity.GetType().GetProperties())
                {
                    table.AddRow(property.Name, property.GetValue(entity));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProducts()
        {
            var entities = await _productDataAccessService.GetByFilter(new ProductFilter());

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProducts");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsAndOrderByNameAscending()
        {
            var filter = new ProductFilter()
            {
                OrderBy = ProductOrderBy.NameAsc
            };

            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsAndOrderByNameAscending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsAndOrderByNameDescending()
        {
            var filter = new ProductFilter()
            {
                OrderBy = ProductOrderBy.NameDesc
            };

            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsAndOrderByNameDescending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsAndOrderByPriceAscending()
        {
            var filter = new ProductFilter()
            {
                OrderBy = ProductOrderBy.PriceAsc
            };

            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsAndOrderByPriceAscending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsAndOrderByPriceDescending()
        {
            var filter = new ProductFilter()
            {
                OrderBy = ProductOrderBy.PriceDesc
            };

            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsAndOrderByPriceDescending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsAndOrderByReviewsAscending()
        {
            var filter = new ProductFilter()
            {
                OrderBy = ProductOrderBy.ReviewsAsc
            };

            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsAndOrderByReviewsAscending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsAndOrderByReviewsDescending()
        {
            var filter = new ProductFilter()
            {
                OrderBy = ProductOrderBy.ReviewsDesc
            };

            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsAndOrderByReviewsDescending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsByCategoryId(int categoryId = 1)
        {
            var filter = new ProductFilter()
            {
                Category = categoryId
            };

            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsByCategoryId");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsBySearchText(string search)
        {
            var filter = new ProductFilter()
            {
                Query = search
            };

            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsBySearchText");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetProductsByFilter(ProductFilter filter)
        {
            var entities = await _productDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Products");
            }
            else
            {
                Console.WriteLine("GetProductsByFilter");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumn("Price", Alignment.Right, Alignment.Right);
                table.AddColumns(Alignment.Center, Alignment.Center, "Rating", "Reviews");
                table.AddColumns(Alignment.Left, Alignment.Left, "Brand", "Categories");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Price, entity.Rating, entity.RatingCount, entity.Brand.Name, string.Join(", ", entity.Categories.Select(c => c.Category.Name)));
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        #endregion

        #region Brands

        public async Task CreateBrand()
        {
            await _brandDataAccessService.Create(new BrandEntity()
            {
                Name = "Bruh"
            });
        }

        public async Task GetBrands()
        {
            var entities = await _brandDataAccessService.GetByFilter(new BrandFilter());

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Brands");
            }
            else
            {
                Console.WriteLine("GetBrands");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumns(Alignment.Center, Alignment.Center, "Products", "Reviews", "Rating");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Products.Count, entity.RatingCount, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetBrandsAndOrderByNameAscending()
        {
            var filter = new BrandFilter()
            {
                OrderBy = BrandOrderBy.NameAsc
            };

            var entities = await _brandDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Brands");
            }
            else
            {
                Console.WriteLine("GetBrandsAndOrderByNameAscending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumns(Alignment.Center, Alignment.Center, "Products", "Reviews", "Rating");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Products.Count, entity.RatingCount, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetBrandsAndOrderByNameDescending()
        {
            var filter = new BrandFilter()
            {
                OrderBy = BrandOrderBy.NameDesc
            };

            var entities = await _brandDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Brands");
            }
            else
            {
                Console.WriteLine("GetBrandsAndOrderByNameDescending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumns(Alignment.Center, Alignment.Center, "Products", "Reviews", "Rating");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Products.Count, entity.RatingCount, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetBrandsAndOrderByProductsAscending()
        {
            var filter = new BrandFilter()
            {
                OrderBy = BrandOrderBy.ProductsAsc
            };

            var entities = await _brandDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Brands");
            }
            else
            {
                Console.WriteLine("GetBrandsAndOrderByProductsAscending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumns(Alignment.Center, Alignment.Center, "Products", "Reviews", "Rating");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Products.Count, entity.RatingCount, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetBrandsAndOrderByProductsDescending()
        {
            var filter = new BrandFilter()
            {
                OrderBy = BrandOrderBy.ProductsDesc
            };

            var entities = await _brandDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Brands");
            }
            else
            {
                Console.WriteLine("GetBrandsAndOrderByProductsDescending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumns(Alignment.Center, Alignment.Center, "Products", "Reviews", "Rating");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Products.Count, entity.RatingCount, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetBrandsBySearchText(string search)
        {
            var filter = new BrandFilter()
            {
                Query = search
            };

            var entities = await _brandDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Brands");
            }
            else
            {
                Console.WriteLine("GetBrandsBySearchText");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumns(Alignment.Center, Alignment.Center, "Products", "Reviews", "Rating");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Products.Count, entity.RatingCount, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetBrandsByFilter(BrandFilter filter)
        {
            var entities = await _brandDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Brands");
            }
            else
            {
                Console.WriteLine("GetBrandsByFilter");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name");
                table.AddColumns(Alignment.Center, Alignment.Center, "Products", "Reviews", "Rating");

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, entity.Products.Count, entity.RatingCount, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        #endregion

        #region Reviews

        public async Task GetReviews()
        {
            var entities = await _reviewDataAccessService.GetByFilter(new ReviewFilter());

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Reviews");
            }
            else
            {
                Console.WriteLine("GetReviews");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Title", "Comment");
                table.AddColumn("Rating", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Title, entity.Comment, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetReviewsAndOrderByRatingAscending()
        {
            var filter = new ReviewFilter()
            {
                OrderBy = ReviewOrderBy.RatingAsc
            };

            var entities = await _reviewDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Reviews");
            }
            else
            {
                Console.WriteLine("GetReviewsAndOrderByRatingAscending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Title", "Comment");
                table.AddColumn("Rating", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Title, entity.Comment, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetReviewsAndOrderByRatingDescending()
        {
            var filter = new ReviewFilter()
            {
                OrderBy = ReviewOrderBy.RatingDesc
            };

            var entities = await _reviewDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Reviews");
            }
            else
            {
                Console.WriteLine("GetReviewsAndOrderByRatingDescending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Title", "Comment");
                table.AddColumn("Rating", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Title, entity.Comment, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetReviewsBySearchText(string search)
        {
            var filter = new ReviewFilter()
            {
                Query = search
            };

            var entities = await _reviewDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Reviews");
            }
            else
            {
                Console.WriteLine("GetReviewsBySearchText");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Title", "Comment");
                table.AddColumn("Rating", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Title, entity.Comment, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetReviewsByProductId(int entityId)
        {
            var filter = new ReviewFilter()
            {
                Product = entityId
            };

            var entities = await _reviewDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Reviews");
            }
            else
            {
                Console.WriteLine($"GetReviewsByProductId = {entityId}");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Title", "Comment");
                table.AddColumn("Rating", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Title, entity.Comment, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetReviewsByFilter(ReviewFilter filter)
        {
            var entities = await _reviewDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Reviews");
            }
            else
            {
                Console.WriteLine("GetReviewsByFilter");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Title", "Comment");
                table.AddColumn("Rating", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Title, entity.Comment, entity.Rating);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        #endregion

        #region Categories

        public async Task GetCategories()
        {
            var entities = await _categoryDataAccessService.GetByFilter(new CategoryFilter());

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Categories");
            }
            else
            {
                Console.WriteLine("GetCategories");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name", "Description");
                table.AddColumn("Products", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, string.Join(" ", entity.Description.Split(" ").Take(10)) + "...", entity.Products.Count);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetCategoriesAndOrderByNameAscending()
        {
            var filter = new CategoryFilter()
            {
                OrderBy = CategoryOrderBy.NameAsc
            };

            var entities = await _categoryDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Categories");
            }
            else
            {
                Console.WriteLine("GetCategoriesAndOrderByNameAscending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name", "Description");
                table.AddColumn("Products", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, string.Join(" ", entity.Description.Split(" ").Take(10)) + "...", entity.Products.Count);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetCategoriesAndOrderByNameDescending()
        {
            var filter = new CategoryFilter()
            {
                OrderBy = CategoryOrderBy.NameDesc
            };

            var entities = await _categoryDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Categories");
            }
            else
            {
                Console.WriteLine("GetCategoriesAndOrderByNameDescending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name", "Description");
                table.AddColumn("Products", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, string.Join(" ", entity.Description.Split(" ").Take(10)) + "...", entity.Products.Count);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetCategoriesAndOrderByProductsAscending()
        {
            var filter = new CategoryFilter()
            {
                OrderBy = CategoryOrderBy.ProductsAsc
            };

            var entities = await _categoryDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Categories");
            }
            else
            {
                Console.WriteLine("GetCategoriesAndOrderByProductsAscending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name", "Description");
                table.AddColumn("Products", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, string.Join(" ", entity.Description.Split(" ").Take(10)) + "...", entity.Products.Count);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetCategoriesAndOrderByProductsDescending()
        {
            var filter = new CategoryFilter()
            {
                OrderBy = CategoryOrderBy.ProductsDesc
            };

            var entities = await _categoryDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Categories");
            }
            else
            {
                Console.WriteLine("GetCategoriesAndOrderByProductsDescending");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name", "Description");
                table.AddColumn("Products", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, string.Join(" ", entity.Description.Split(" ").Take(10)) + "...", entity.Products.Count);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetCategoriesBySearch(string search)
        {
            var filter = new CategoryFilter()
            {
                Query = search
            };

            var entities = await _categoryDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Categories");
            }
            else
            {
                Console.WriteLine("GetCategoriesBySearch");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name", "Description");
                table.AddColumn("Products", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, string.Join(" ", entity.Description.Split(" ").Take(10)) + "...", entity.Products.Count);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        public async Task GetCategoriesByFilter(CategoryFilter filter)
        {
            var entities = await _categoryDataAccessService.GetByFilter(filter);

            #region Irrelevant

            if (!entities.Any())
            {
                Console.WriteLine("No Categories");
            }
            else
            {
                Console.WriteLine("GetCategoriesByFilter");

                var table = new Table()
                {
                    Config = TableConfiguration.Unicode()
                };

                table.AddColumns(Alignment.Left, Alignment.Left, "ID", "Name", "Description");
                table.AddColumn("Products", Alignment.Center, Alignment.Center);

                foreach (var entity in entities)
                {
                    table.AddRow(entity.EntityId, entity.Name, string.Join(" ", entity.Description.Split(" ").Take(10)) + "...", entity.Products.Count);
                }

                Console.Write(table.ToString());
            }

            Console.WriteLine();

            #endregion
        }

        #endregion
    }
}
