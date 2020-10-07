namespace TheWebShop.Common.Filters.Category
{
    public class CategoryFilter : BaseFilter<CategoryOrderBy>
    {
        public CategoryFilter()
        {
            OrderBy = CategoryOrderBy.None;
        }

        public override CategoryOrderBy OrderBy { get; set; }
    }
}