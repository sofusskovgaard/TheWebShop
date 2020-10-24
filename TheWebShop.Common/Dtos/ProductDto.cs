using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Dtos;

namespace TheWebShop.Common.Dtos
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }

        public string NameWithBrand => Brand != null ? $"{Brand.Name} - {Name}" : Name;
        
        public string Description { get; set; }
        
        public BrandDto Brand { get; set; }
        
        public int BrandEntityId { get; set; }
        
        public decimal Price { get; set; }

        public decimal Rating { get; set; }

        public int RatingCount { get; set; }
        
        public bool Highlight { get; set; }
        
        public bool InStock { get; set; }
        
        public int Stock { get; set; }
    }

    public class ProductWithPicturesDto : ProductDto
    {
        public List<ProductPictureDto> Pictures { get; set; }
    }

    public class ProductDetailedDto : ProductDto
    {
        public List<ProductPictureDto> Pictures { get; set; }
        
        public List<CategoryDto> Categories { get; set; }

        public List<ReviewDto> Reviews { get; set; }
    }
}
