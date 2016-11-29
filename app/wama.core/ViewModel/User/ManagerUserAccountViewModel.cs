using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public class ManagerUserAccountViewModel : UserAccountViewModel
    {
        public override UserAccountType AccountType { get; } = UserAccountType.Manager;
    }
}