using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;
using Xunit;

namespace WAMAcut.ViewModel.User
{
    public class EmployeeUserAccountViewModelTests
    {
        [Fact]
        public void UserAccountTypeTest()
        {
            var userViewModel = new EmployeeUserAccountViewModel();
            Assert.Equal(UserAccountType.Employee, userViewModel.AccountType);
        }
    }
}