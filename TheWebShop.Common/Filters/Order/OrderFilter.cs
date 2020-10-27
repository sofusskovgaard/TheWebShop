namespace TheWebShop.Common.Filters.Order
{
    public class OrderFilter : BaseFilter<OrderOrderBy>
    {
        public override OrderOrderBy OrderBy { get; set; }
    }
}