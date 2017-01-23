using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;
using Xunit;

namespace WAMAcut.ViewModel.User
{
    public class AdministratorUserAccountViewModelTests
    {
        [Fact]
        public void UserAccountTypeTest()
        {
            var userViewModel = new AdministratorUserAccountViewModel();
            Assert.Equal(UserAccountType.Administrator, userViewModel.AccountType);
        }
    }
}