using System.ComponentModel.DataAnnotations.Schema;

using TheWebShop.Data.Entities.Product;

namespace TheWebShop.Data.Entities.Review
{
    [Table("Reviews")]
    public class ReviewEntity : BaseEntity, IReviewEntity
    {
        public int Rating { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public int ProductEntityId { get; set; }

        public ProductEntity Product { get; set; }
    }
}