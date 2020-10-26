using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Microsoft.AspNetCore.Identity;

namespace TheWebShop.Data.Entities.User
{
    [Table("Users")]
    public class UserEntity : IdentityUser<int>
    {
        [ProtectedPersonalData]
        public string Firstname { get; set; }

        [ProtectedPersonalData]
        public string Lastname { get; set; }
    }
}
