using System.Collections.Generic;

namespace WAMA.Core.Models.DTOs
{
    /// <summary>
    /// Represents UserAccount
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.DTOs.TableRow" />
    public class UserAccount : TableRow
    {
        /// <summary>
        /// Gets or sets the type of the account.
        /// </summary>
        /// <value>
        /// The type of the account.
        /// </value>
        public UserAccountType AccountType { get; set; }

        /// <summary>
        /// Gets or sets the member identifier of this UserAccount.
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// Gets or sets the first name of this UserAccount.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of this UserAccount.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the email of this UserAccount.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the gender of this UserAccount.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Gets or sets the institution affiliation of this UserAccount.
        /// </summary>
        public InstitutionAffiliation InstitutionAffiliation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has been approved.
        /// </summary>
        public bool HasBeenApproved { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is suspended.
        /// </summary>
        public bool IsSuspended { get; set; }

        /// <summary>
        /// Gets or sets the log in credential of this UserAccount.
        /// </summary>
        public virtual LogInCredential LogInCredential { get; set; }
        /// <summary>
        /// Gets or sets the certifications of this UserAccount.
        /// </summary>
        public virtual List<Certification> Certifications { get; set; }
        /// <summary>
        /// Gets or sets the waivers of this UserAccount.
        /// </summary>
        public virtual IList<Waiver> Waivers { get; set; }
        /// <summary>
        /// Gets or sets the check in activities of this UserAccount.
        /// </summary>
        public virtual IList<CheckInActivity> CheckInActivities { get; set; }
    }
}