using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

using TheWebShop.Common.Dtos;

namespace TheWebShop.Common.Models
{
    public class BasketItemModel
    {
        public int Quantity { get; set; }

        public int ProductEntityId { get; set; }

        [JsonIgnore]
        public ProductDto Product { get; set; }
    }
}
