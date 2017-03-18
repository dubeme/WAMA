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
        public string MemberId { get; set; }

        /// <summary>
        /// Gets or sets the password of this LogInCredentialViewModel.
        /// </summary>
        public string Password { get; set; }

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