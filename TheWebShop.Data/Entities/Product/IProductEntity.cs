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

        int? BrandEntityId { get; set; }

        BrandEntity Brand { get; set; }

        double Price { get; set; }

        ICollection<ProductPictureEntity> Pictures { get; set; }

        ICollection<ProductCategoryEntity> Categories { get; set; }

        ICollection<ReviewEntity> Reviews { get; set; }
    }
}
