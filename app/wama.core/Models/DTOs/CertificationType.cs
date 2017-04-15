using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents different certification types
    /// </summary>
    public enum CertificationType
    {
        /// <summary>
        /// The unknown
        /// </summary>
        [Display(Name = " --- ")]
        Unknown,
        /// <summary>
        /// The belay
        /// </summary>
        Belay,
        /// <summary>
        /// The lead climb
        /// </summary>
        LeadClimb
    }
}