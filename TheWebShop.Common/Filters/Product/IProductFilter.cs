namespace TheWebShop.Common.Filters.Product
{
    public interface IProductFilter : IBaseFilter<ProductOrderBy>
    {
        double? MinPrice { get; set; }

        double? MaxPrice { get; set; }

        int? MinRating { get; set; }

        int? MaxRating { get; set; }

        int? Brand { get; set; }
        
        int? Category { get; set; }
        
        bool IncludeOutOfStock { get; set; } 

        ProductOrderBy OrderBy { get; set; }
    }
}