using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.UserAccount
{
    public class ManagerUserAccountViewModel : UserAccountViewModel
    {
        public new UserAccountType AccountType { get; } = UserAccountType.Manager;
    }
}