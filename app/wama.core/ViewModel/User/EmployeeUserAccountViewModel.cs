using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public class EmployeeUserAccountViewModel : UserAccountViewModel
    {
        public override UserAccountType AccountType { get; } = UserAccountType.Employee;
    }
}