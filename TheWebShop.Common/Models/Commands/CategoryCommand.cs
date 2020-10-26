namespace TheWebShop.Common.Models.Commands
{
    public class CategoryCommand
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int? ParentCategoryEntityId { get; set; }
    }
}