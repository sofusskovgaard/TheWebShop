using System.Collections.Generic;
using TheWebShop.Common.Dtos;

namespace TheWebShop.Common.Models.Components
{
    public class ProductCardModel
    {
        public ProductDto Product { get; set; }
        
        public IEnumerable<ProductPictureDto> Pictures { get; set; }
    }
}