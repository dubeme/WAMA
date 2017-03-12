using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents TableRow
    /// </summary>
    public abstract class TableRow
    {
        /// <summary>
        /// The created on
        /// </summary>
        private DateTimeOffset? _CreatedOn;

        /// <summary>
        /// Gets or sets the identifier of this TableRow.
        /// </summary>
        [Key]
        public int __ID { get; set; }

        /// <summary>
        /// Gets or sets the created on of this TableRow.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the last updated on of this TableRow.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset __LastUpdatedOn { get; set; }
    }
}