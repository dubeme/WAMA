using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents different types of gender
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// The unknown
        /// </summary>
        [Display(Name = " --- ")]
        Unknown = 0,
        /// <summary>
        /// The male
        /// </summary>
        Male = 1,
        /// <summary>
        /// The female
        /// </summary>
        Female = 2,
        /// <summary>
        /// The other
        /// </summary>
        Other = 3,
        /// <summary>
        /// The preffer not to say
        /// </summary>
        [Display(Name = "Prefer not to say")]
        PrefferNotToSay = 4
    }
}