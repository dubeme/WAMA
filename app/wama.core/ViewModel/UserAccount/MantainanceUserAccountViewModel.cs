using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.UserAccount
{
    public class MantainanceUserAccountViewModel : UserAccountViewModel
    {
        public new UserAccountType AccountType { get; } = UserAccountType.Mantainance;
    }
}