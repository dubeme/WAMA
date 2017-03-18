using System;

namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents CheckInActivity
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.DTOs.TableRow" />
    public class CheckInActivity : TableRow
    {
        /// <summary>
        /// Gets or sets the member identifier of this CheckInActivity.
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// Gets or sets the check in date time of this CheckInActivity.
        /// </summary>
        public DateTimeOffset CheckInDateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is checked in.
        /// </summary>
        public bool IsCheckedIn { get; set; }

        /// <summary>
        /// Gets or sets the member of this CheckInActivity.
        /// </summary>
        public virtual UserAccount Member { get; set; }
    }
}