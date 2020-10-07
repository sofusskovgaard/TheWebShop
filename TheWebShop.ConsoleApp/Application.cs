using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Filters.Brand;
using TheWebShop.Common.Filters.Category;
using TheWebShop.Common.Filters.Product;
using TheWebShop.Common.Filters.Review;
using TheWebShop.Services.DataAccessServices.Brand;
using TheWebShop.Services.DataAccessServices.Category;
using TheWebShop.Services.DataAccessServices.Product;
using TheWebShop.Services.DataAccessServices.Review;

namespace TheWebShop.ConsoleApp
{
    class Application
    {

        private readonly ProductDataAccessService _productDataAccessService;

        private readonly BrandDataAccessService _brandDataAccessService;

        private readonly ReviewDataAccessService _reviewDataAccessService;

        private readonly CategoryDataAccessService _categoryDataAccessService;

        public Application(
            ProductDataAccessService productDataAccessService,
            BrandDataAccessService brandDataAccessService,
            ReviewDataAccessService reviewDataAccessService,
            CategoryDataAccessService categoryDataAccessService)
        {
            _productDataAccessService = productDataAccessService;
            _brandDataAccessService = brandDataAccessService;
            _reviewDataAccessService = reviewDataAccessService;
            _categoryDataAccessService = categoryDataAccessService;
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Sjofus's Sjofle Tjobak Butjik\n");

            GetProducts();
            GetBrands();
            GetReviews();
            GetCategories();
        }

        public void GetProducts()
        {
            var entities = _productDataAccessService.GetByFilter(new ProductFilter());

            entities.Wait();

            Console.WriteLine("Products:");
            Console.WriteLine("------------------------------------");
            foreach (var entity in entities.Result)
            {
                Console.WriteLine($"ID\t= {entity.EntityId}");
                Console.WriteLine($"Name\t= {entity.Name}");
                Console.WriteLine($"Brand\t= {entity.Brand.Name}");
                Console.WriteLine($"Price\t= {entity.Price}");
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
        }

        public void GetBrands()
        {
            var entities = _brandDataAccessService.GetByFilter(new BrandFilter());

            entities.Wait();

            Console.WriteLine("Brands:");
            Console.WriteLine("------------------------------------");
            foreach (var entity in entities.Result)
            {
                Console.WriteLine($"ID\t= {entity.EntityId}");
                Console.WriteLine($"Name\t= {entity.Name}");
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
        }

        public void GetReviews()
        {
            var entities = _reviewDataAccessService.GetByFilter(new ReviewFilter());

            entities.Wait();

            Console.WriteLine("Reviews:");
            Console.WriteLine("------------------------------------");
            foreach (var entity in entities.Result)
            {
                Console.WriteLine($"ID\t= {entity.EntityId}");
                Console.WriteLine($"Title\t= {entity.Title}");
                Console.WriteLine($"Comment = {entity.Comment}");
                Console.WriteLine($"Rating\t= {entity.Rating}");
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
        }

        public void GetCategories()
        {
            var entities = _categoryDataAccessService.GetByFilter(new CategoryFilter());

            entities.Wait();

            Console.WriteLine("Categories:");
            Console.WriteLine("------------------------------------");
            foreach (var entity in entities.Result)
            {
                Console.WriteLine($"ID\t= {entity.EntityId}");
                Console.WriteLine($"Title\t= {entity.Name}");
                Console.WriteLine($"Children\t= {entity.ChildCategories.Count}");
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
        }
    }
}
