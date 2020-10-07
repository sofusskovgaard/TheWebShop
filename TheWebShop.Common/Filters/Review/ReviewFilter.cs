namespace TheWebShop.Common.Filters.Review
{
    public class ReviewFilter : BaseFilter<ReviewOrderBy>
    {
        public ReviewFilter()
        {
            OrderBy = ReviewOrderBy.None;
        }

        public int? MinRating { get; set; }

        public int? MaxRating { get; set; }

        public int? Product { get; set; }

        public override ReviewOrderBy OrderBy { get; set; }
    }
}