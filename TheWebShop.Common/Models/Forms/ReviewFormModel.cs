using System.ComponentModel.DataAnnotations;
using TheWebShop.Common.Models.Product;

namespace TheWebShop.Common.Models.Forms
{
    public class ReviewFormModel : BaseFormModel
    {
        [Required, MinLength(1), MaxLength(1), Range(1, 5)]
        public int Rating { get; set; }
        
        [Required, MinLength(16)]
        public string Title { get; set; }
        
        [Required, MinLength(32), MaxLength(1024)]
        public string Comment { get; set; }
        
        [Required]
        public int ProductEntityId { get; set; }
    }
}