using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public class MantainanceUserAccountViewModel : UserAccountViewModel
    {
        public override UserAccountType AccountType { get; } = UserAccountType.Mantainance;
    }
}