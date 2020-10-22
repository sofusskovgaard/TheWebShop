using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheWebShop.Common.Filters.Product
{
    public enum ProductOrderBy
    {
        None,
        [Display(Name = "A - Z")]
        NameAsc,
        [Display(Name =  "Z - A")]
        NameDesc,
        [Display(Name = "Least Popular")]
        ReviewsAsc,
        [Display(Name = "Most Popular")]
        ReviewsDesc,
        [Display(Name = "Lowest Price")]
        PriceAsc,
        [Display(Name = "Highest Price")]
        PriceDesc,
        [Display(Name = "Oldest")]
        CreatedAtAsc,
        [Display(Name = "Newest")]
        CreatedAtDesc
    }
}
