namespace TheWebShop.Common.Models.Commands
{
    public class ReviewCommand
    {
        public int Rating { get; set; }
        
        public string Title { get; set; }
        
        public string Comment { get; set; }
        
        public int ProductEntityId { get; set; }
    }
}