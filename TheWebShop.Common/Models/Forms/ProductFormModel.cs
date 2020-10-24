namespace TheWebShop.Common.Models.Product
{
    public class ProductFormModel : BaseFormModel
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int? BrandEntityId { get; set; }
        
        public decimal Price { get; set; }
        
        public int Stock { get; set; }
        
        public bool Highlight { get; set; }
    }
}