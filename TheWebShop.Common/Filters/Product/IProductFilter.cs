namespace TheWebShop.Common.Filters.Product
{
    public interface IProductFilter : IBaseFilter<ProductOrderBy>
    {
        decimal? MinPrice { get; set; }

        decimal? MaxPrice { get; set; }

        decimal? MinRating { get; set; }

        decimal? MaxRating { get; set; }

        int? Brand { get; set; }
        
        int? Category { get; set; }
        
        bool IncludeOutOfStock { get; set; } 

        ProductOrderBy OrderBy { get; set; }
    }
}