using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    /// <summary>
    /// Represents PatronUserAccountViewModel
    /// </summary>
    /// <seealso cref="WAMA.Core.ViewModel.User.UserAccountViewModel" />
    public class PatronUserAccountViewModel : UserAccountViewModel
    {
        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        public override UserAccountType AccountType { get; } = UserAccountType.Patron;
    }
}