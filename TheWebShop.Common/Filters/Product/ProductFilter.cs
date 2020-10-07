using System;
using System.Collections.Generic;
using System.Text;

namespace TheWebShop.Common.Filters.Product
{
    public class ProductFilter : BaseFilter<ProductOrderBy>
    {
        public ProductFilter()
        {
            OrderBy = ProductOrderBy.None;
        }

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }

        public int? MinRating { get; set; }

        public int? MaxRating { get; set; }

        public int? Category { get; set; }

        public override ProductOrderBy OrderBy { get; set; }
    }
}
