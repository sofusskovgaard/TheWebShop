using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.ProductPicture
{
    public interface IProductPictureEntity : IBaseEntity
    {
        int? ProductEntityId { get; set; }

        ProductEntity Product { get; set; }

        string Caption { get; set; }

        byte[] Picture { get; set; }
    }
}
