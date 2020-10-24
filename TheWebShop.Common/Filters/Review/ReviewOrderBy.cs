using System.ComponentModel.DataAnnotations;

namespace TheWebShop.Common.Filters.Review
{
    public enum ReviewOrderBy
    {
        None,
        [Display(Name = "Lowest Rating")]
        RatingAsc,
        [Display(Name = "Highest Rating")]
        RatingDesc,
        [Display(Name = "Oldest")]
        CreatedAtAsc,
        [Display(Name = "Newest")]
        CreatedAtDesc
    }
}