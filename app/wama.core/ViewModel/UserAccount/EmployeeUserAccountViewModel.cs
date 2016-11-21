using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.UserAccount
{
    public class EmployeeUserAccountViewModel : UserAccountViewModel
    {
        public new UserAccountType AccountType { get; } = UserAccountType.Employee;
    }
}