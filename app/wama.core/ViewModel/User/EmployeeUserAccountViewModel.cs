using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public class EmployeeUserAccountViewModel : UserAccountViewModel
    {
        public new UserAccountType AccountType { get; } = UserAccountType.Employee;
    }
}