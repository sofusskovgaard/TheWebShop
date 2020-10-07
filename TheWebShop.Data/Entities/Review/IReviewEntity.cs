using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.Review
{
    public interface IReviewEntity : IBaseEntity
    {
        int Rating { get; set; }

        string Comment { get; set; }

        int ProductEntityId { get; set; }
        ProductEntity Product { get; set; }
    }
}