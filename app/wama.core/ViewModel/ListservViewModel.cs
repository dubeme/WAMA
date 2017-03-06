using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.Contracts;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents ListservViewModel
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.Contracts.ISerializableToCSV" />
    public class ListservViewModel : ISerializableToCSV
    {
        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public virtual UserAccountType AccountType { get; }

        /// <summary>
        /// Gets or sets the first name of this ListservViewModel.
        /// </summary>
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of this ListservViewModel.
        /// </summary>
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the email of this ListservViewModel.
        /// </summary>
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        public IEnumerable<string> Headers
        {
            get
            {
                return new string[] {
                    nameof(FirstName),
                    nameof(LastName),
                    nameof(MiddleName),
                    nameof(Email)
                };
            }
        }

        /// <summary>
        /// Gets the CSV string.
        /// </summary>
        public IEnumerable<string> CSVString
        {
            get
            {
                return new string[] {
                    FirstName,
                    LastName,
                    MiddleName,
                    Email
                };
            }
        }
    }
}