using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;
using Xunit;

namespace WAMAcut.ViewModel.User
{
    public class MantainanceUserAccountViewModelTests
    {
        [Fact]
        public void UserAccountTypeTest()
        {
            var userViewModel = new MantainanceUserAccountViewModel();
            Assert.Equal(UserAccountType.Mantainance, userViewModel.AccountType);
        }

        [Fact]
        public void UserAccountPropertiesTest()
        {
            var userViewModel = UserAccountViewModelHelper
                .UserAccountTypeTest<MantainanceUserAccountViewModel>();
            // TODO: finish up
        }
    }
}