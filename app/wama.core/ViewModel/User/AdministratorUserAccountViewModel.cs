using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    /// <summary>
    /// Represents AdministratorUserAccountViewModel
    /// </summary>
    /// <seealso cref="WAMA.Core.ViewModel.User.UserAccountViewModel" />
    public class AdministratorUserAccountViewModel : UserAccountViewModel
    {
        /// <summary>
        /// Gets the type of the account.
        /// </summary>
        public override UserAccountType AccountType { get; } = UserAccountType.Administrator;
    }
}