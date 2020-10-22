using System;
using System.Collections.Generic;
using System.Text;

using TheWebShop.Common.Dtos;

namespace TheWebShop.Common.Models
{
    public class BasketModel
    {
        public List<BasketItemModel> Items { get; set; } = new List<BasketItemModel>();
    }
}
