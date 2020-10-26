using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;using Microsoft.AspNetCore.Identity;

namespace TheWebShop.Data.Entities.Role
{
    [Table("Roles")]
    public class RoleEntity : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
