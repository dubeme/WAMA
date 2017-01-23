using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;
using Xunit;

namespace WAMAcut.ViewModel.User
{
    public class ManagerUserAccountViewModelTests
    {
        [Fact]
        public void UserAccountTypeTest()
        {
            var userViewModel = new ManagerUserAccountViewModel();
            Assert.Equal(UserAccountType.Manager, userViewModel.AccountType);
        }
    }
}