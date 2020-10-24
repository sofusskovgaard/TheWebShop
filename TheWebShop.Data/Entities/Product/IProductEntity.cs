using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Data.Entities.Brand;
using TheWebShop.Data.Entities.ProductCategory;
using TheWebShop.Data.Entities.ProductPicture;
using TheWebShop.Data.Entities.Review;

namespace TheWebShop.Data.Entities.Product
{
    public interface IProductEntity : IBaseEntity
    {
        string Name { get; set; }
        
        string Description { get; set; }

        int? BrandEntityId { get; set; }

        BrandEntity Brand { get; set; }

        decimal Price { get; set; }

        ICollection<ProductPictureEntity> Pictures { get; set; }

        ICollection<ProductCategoryEntity> Categories { get; set; }

        decimal Rating { get; }
        
        int RatingCount { get; }
        
        bool Highlight { get; set; }
        
        bool InStock { get; }
        
        int Stock { get; set; }
        
        ICollection<ReviewEntity> Reviews { get; set; }
    }
}
