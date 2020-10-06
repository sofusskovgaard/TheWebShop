using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.ProductPicture
{
    public class ProductPictureEntity : BaseEntity, IProductPictureEntity
    {
        public int? ProductEntityId { get; set; }

        public ProductEntity Product { get; set; }

        public string Caption { get; set; }

        public byte[] Picture { get; set; }
    }
}
