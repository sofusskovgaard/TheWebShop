using System.ComponentModel.DataAnnotations;

namespace TheWebShop.Common.Filters.Order
{
    public enum OrderOrderBy
    {
        None,
        [Display(Name = "Lowest Price")]
        PriceAsc,
        [Display(Name = "Highest Price")]
        PriceDesc,
        [Display(Name = "Least Products")]
        ProductsAsc,
        [Display(Name = "Most Products")]
        ProductsDesc,
        [Display(Name = "Oldest")]
        CreatedAtAsc,
        [Display(Name = "Newest")]
        CreatedAtDesc
    }
}