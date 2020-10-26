using System.ComponentModel.DataAnnotations;
using TheWebShop.Common.Models.Product;

namespace TheWebShop.Common.Models.Forms
{
    public class CategoryFormModel : BaseFormModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required, MinLength(32), MaxLength(1024)]
        public string Description { get; set; }
        
        public int? ParentCategoryEntityId { get; set; }
    }
}