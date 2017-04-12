using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents LogInCredentialViewModel
    /// </summary>
    public class LogInCredentialViewModel
    {
        /// <summary>
        /// Gets or sets the member identifier of this LogInCredentialViewModel.
        /// </summary>
        [Required]
        [Display(Name = "Member ID")]
        public string MemberId { get; set; }

        /// <summary>
        /// Gets or sets the password of this LogInCredentialViewModel.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the confirm password of this LogInCredentialViewModel.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the current password of this LogInCredentialViewModel. <para />
        /// Used only for displaying the view for setting a password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        public bool PassWordsMatch
        {
            get
            {
                return Equals(Password, null) == false &&
                    Equals(ConfirmPassword, null) == false &&
                    Password.Equals(ConfirmPassword);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [password is set].
        /// </summary>
        public bool PasswordIsSet { get; set; }

        public string PasswordSetRequestVerificationToken { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [requires password].
        /// </summary>
        public bool RequiresPassword { get; set; }

        /// <summary>
        /// Gets or sets the member of this LogInCredentialViewModel.
        /// </summary>
        public virtual UserAccount Member { get; set; }
    }
}