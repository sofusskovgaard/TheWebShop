using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Dtos.Product;

namespace TheWebShop.Common.Dtos.Brand
{
    public class BrandDto : BaseDto
    {
        public string Name { get; set; }
    }

    public class BrandDetailedDto : BrandDto {
        public List<ProductDto> Products { get; set; }

        public double Rating { get; set; }

        public int RatingCount { get; set; }
    }
}
