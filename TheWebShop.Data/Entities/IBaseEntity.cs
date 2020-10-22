using System;
using System.Collections.Generic;
using System.Text;

namespace TheWebShop.Data.Entities
{
    public interface IBaseEntity
    {
        int EntityId { get; set; }
        
        bool Active { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }

        byte[] RowVersion { get; set; }
    }
}
