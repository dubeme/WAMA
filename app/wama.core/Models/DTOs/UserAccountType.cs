using System.ComponentModel.DataAnnotations;
namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents different account types
    /// </summary>
    
    public enum UserAccountType
    {
        /// <summary>
        /// The unknown
        /// </summary>
        [Display(Name = " --- ")]
        Patron = 1,
        /// <summary>
        /// The employee
        /// </summary>
        Employee = 2,
        /// <summary>
        /// The manager
        /// </summary>
        Manager = 4,
        /// <summary>
        /// The administrator
        /// </summary>
        Administrator = 8,
        /// <summary>
        /// The mantainance
        /// </summary>
        Mantainance = 16
    }
}