using System;
using System.Collections.Generic;
using System.Text;

namespace TheWebShop.Common.Filters.Product
{
    public class ProductFilter : BaseFilter<ProductOrderBy>, IProductFilter
    {
        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }

        public int? MinRating { get; set; }

        public int? MaxRating { get; set; }

        public int? Brand { get; set; }
        
        public int? Category { get; set; }

        public bool PrioritizeHighlighted { get; set; } = true;

        public bool IncludeOutOfStock { get; set; } = true;

        public bool IncludeInactive { get; set; } = false;

        public override ProductOrderBy OrderBy { get; set; } = ProductOrderBy.None;
    }
}
