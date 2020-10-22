using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Dtos;

namespace TheWebShop.Common.Dtos
{
    public class BrandDto : BaseDto
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Website { get; set; }
        
        public string PhoneNumber { get; set; }

        public int ProductCount { get; set; }
    }

    public class BrandDetailedDto : BrandDto {
        public List<ProductDto> Products { get; set; }

        public double Rating { get; set; }

        public int RatingCount { get; set; }
    }
}
