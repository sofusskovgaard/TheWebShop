using System.ComponentModel.DataAnnotations;

namespace TheWebShop.Common.Models.Product
{
    public class ProductFormModel : BaseFormModel
    {
        [Required, MinLength(1)]
        public string Name { get; set; }
        
        [Required, MinLength(1), MaxLength(2048)]
        public string Description { get; set; }
        
        public int? BrandEntityId { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public int Stock { get; set; }
        
        public bool Highlight { get; set; }
    }
}