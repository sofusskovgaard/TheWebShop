using System.Collections.Generic;

namespace TheWebShop.Common.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        
        public string Firstname { get; set; }
        
        public string Lastname { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
    }

    public class UserWithOrdersDto : UserDto
    {
        public List<OrderDto> Orders { get; set; }
    }
}