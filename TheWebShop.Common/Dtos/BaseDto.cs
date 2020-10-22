using System;
using System.Collections.Generic;
using System.Text;

namespace TheWebShop.Common.Dtos
{
    public class BaseDto
    {
        public int EntityId { get; set; }

        public bool Active { get; set; }
        
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
