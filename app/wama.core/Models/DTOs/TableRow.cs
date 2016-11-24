using System;
using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.Models.DTOs
{
    public abstract class TableRow
    {
        [Key]
        public int __ID { get; set; }

        public DateTimeOffset __CreatedOn { get; set; }
    }
}