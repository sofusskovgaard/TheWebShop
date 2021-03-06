﻿namespace TheWebShop.Common.Filters.Brand
{
    public class BrandFilter : BaseFilter<BrandOrderBy>
    {
        public BrandFilter()
        {
            OrderBy = BrandOrderBy.None;
        }

        public bool IncludeInactive { get; set; } = false;
        
        public override BrandOrderBy OrderBy { get; set; }
    }
}
