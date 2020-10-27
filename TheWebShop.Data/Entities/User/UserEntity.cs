using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Microsoft.AspNetCore.Identity;
using TheWebShop.Data.Entities.Order;

namespace TheWebShop.Data.Entities.User
{
    [Table("Users")]
    public class UserEntity : IdentityUser<int>, IUserEntity
    {
        [ProtectedPersonalData]
        public string Firstname { get; set; }

        [ProtectedPersonalData]
        public string Lastname { get; set; }
        
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
