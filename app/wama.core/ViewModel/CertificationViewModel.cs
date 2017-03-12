using System;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents CertificationViewModel
    /// </summary>
    public class CertificationViewModel
    {
        /// <summary>
        /// Gets or sets the member identifier of this CertificationViewModel.
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// Gets or sets the type of this CertificationViewModel.
        /// </summary>
        public CertificationType Type { get; set; }
        /// <summary>
        /// Gets or sets the certified on of this CertificationViewModel.
        /// </summary>
        public DateTimeOffset CertifiedOn { get; set; }
        /// <summary>
        /// Gets or sets the expires on of this CertificationViewModel.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the member of this CertificationViewModel.
        /// </summary>
        public virtual UserAccount Member { get; set; }
    }
}