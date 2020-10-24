using TheWebShop.Common.Models.Product;

namespace TheWebShop.Common.Models.Forms
{
    public class ReviewFormModel : BaseFormModel
    {
        public int Rating { get; set; }
        
        public string Title { get; set; }
        
        public string Comment { get; set; }
        
        public int ProductEntityId { get; set; }
    }
}