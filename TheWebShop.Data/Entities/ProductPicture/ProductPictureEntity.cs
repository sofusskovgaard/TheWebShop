using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.ProductPicture
{
    [Table("ProductPictures")]
    public class ProductPictureEntity : BaseEntity, IProductPictureEntity
    {
        public int? ProductEntityId { get; set; }

        public ProductEntity Product { get; set; }

        public string Caption { get; set; }

        public string Picture { get; set; }
    }
}
