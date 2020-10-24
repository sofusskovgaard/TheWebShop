namespace TheWebShop.Common.Filters.Category
{
    public class CategoryFilter : BaseFilter<CategoryOrderBy>
    {
        public CategoryFilter()
        {
            OrderBy = CategoryOrderBy.None;
        }
        
        public int? Parent { get; set; }

        public bool IncludeInactive { get; set; } = false;

        public override CategoryOrderBy OrderBy { get; set; }
    }
}