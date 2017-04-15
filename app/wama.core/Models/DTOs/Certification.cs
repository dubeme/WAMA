using System;

namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents Certification
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.DTOs.TableRow" />
    public class Certification : TableRow
    {
        /// <summary>
        /// Gets or sets the member identifier of this Certification.
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// Gets or sets the type of this Certification.
        /// </summary>
        public CertificationType Type { get; set; }
        /// <summary>
        /// Gets or sets the certified on of this Certification.
        /// </summary>
        public DateTime CertifiedOn { get; set; }
        /// <summary>
        /// Gets or sets the expires on of this Certification.
        /// </summary>
        public DateTime ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the member of this Certification.
        /// </summary>
        public virtual UserAccount Member { get; set; }
    }
}