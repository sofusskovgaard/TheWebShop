using TheWebShop.Common.Models.Product;

namespace TheWebShop.Common.Models.Forms
{
    public class CategoryFormModel : BaseFormModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int? ParentCategoryEntityId { get; set; }
    }
}