using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TheWebShop.Data.Entities.Order;

namespace TheWebShop.Data.Entities.User
{
    public interface IUserEntity
    {
        string Firstname { get; set; }
        
        string Lastname { get; set; }
        
        ICollection<OrderEntity> Orders { get; set; }
    }
}