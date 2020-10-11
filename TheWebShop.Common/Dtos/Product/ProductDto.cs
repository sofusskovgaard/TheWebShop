using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Dtos.Brand;
using TheWebShop.Common.Dtos.Category;
using TheWebShop.Common.Dtos.ProductPicture;
using TheWebShop.Common.Dtos.Review;

namespace TheWebShop.Common.Dtos.Product
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        
        public BrandDto Brand { get; set; }

        public double Price { get; set; }

        public List<ProductPictureDto> Pictures { get; set; }

        public double Rating { get; set; }

        public int RatingCount { get; set; }
    }

    public class ProductDetailedDto : ProductDto
    {
        public List<CategoryDto> Categories { get; set; }

        public List<ReviewDto> Reviews { get; set; }
    }
}
