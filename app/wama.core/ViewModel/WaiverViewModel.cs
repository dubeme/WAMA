using System;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents WaiverViewModel
    /// </summary>
    public class WaiverViewModel
    {
        /// <summary>
        /// Gets or sets the member identifier of this WaiverViewModel.
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// Gets or sets the signed on of this WaiverViewModel.
        /// </summary>
        public DateTimeOffset SignedOn { get; set; }

        /// <summary>
        /// Gets or sets the member that owns this WaiverViewModel.
        /// </summary>
        public virtual UserAccount Member { get; set; }
    }
}