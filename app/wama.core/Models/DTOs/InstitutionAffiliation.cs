using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents Institution affiliation
    /// </summary>
    public enum InstitutionAffiliation
    {
        /// <summary>
        /// The unknown
        /// </summary>
        [Display(Name = " --- ")]
        Unknown = 0,
        /// <summary>
        /// The student
        /// </summary>
        Student = 1,
        /// <summary>
        /// The faculty
        /// </summary>
        Faculty = 2,
        /// <summary>
        /// The staff
        /// </summary>
        Staff = 3,
        /// <summary>
        /// The outsider
        /// </summary>
        Outsider = 4
    }
}