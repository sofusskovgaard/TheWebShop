using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheWebShop.Data.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Key]
        public int EntityId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
