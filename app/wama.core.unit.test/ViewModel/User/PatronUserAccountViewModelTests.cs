using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;
using Xunit;

namespace WAMAcut.ViewModel.User
{
    public class PatronUserAccountViewModelTests
    {
        [Fact]
        public void UserAccountTypeTest()
        {
            var userViewModel = new PatronUserAccountViewModel();
            Assert.Equal(UserAccountType.Patron, userViewModel.AccountType);
        }
    }
}