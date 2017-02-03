using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAMA.Core.Models.DTOs
{
    public abstract class TableRow
    {
        private DateTimeOffset? _CreatedOn;

        [Key]
        public int __ID { get; set; }

        public DateTimeOffset __CreatedOn
        {
            get
            {
                return _CreatedOn ?? DateTimeOffset.Now;
            }
            set
            {
                _CreatedOn = value;
            }
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset __LastUpdatedOn { get; set; } = DateTimeOffset.Now;
    }
}