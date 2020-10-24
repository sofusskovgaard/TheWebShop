using System.ComponentModel.DataAnnotations;

namespace TheWebShop.Common.Filters.Category
{
    public enum CategoryOrderBy
    {
        None,
        [Display(Name = "A - Z")]
        NameAsc,
        [Display(Name = "Z -A")]
        NameDesc,
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