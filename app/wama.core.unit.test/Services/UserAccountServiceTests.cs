using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Services;
using WAMA.Core.ViewModel;
using WAMA.Core.ViewModel.User;
using Xunit;

namespace WAMAcut.Services
{
    public class UserAccountServiceTests
    {
        private const int NUMBER_OF_USER_ACCOUNTS_IN_JSON_FILE = 42;
        private const string TEST_MEMBER_ID = "1234567";

        private DbContextOptions InMemoryDbOption;
        private UserAccountService _UserAccountService;

        public UserAccountServiceTests()
        {
            InMemoryDbOption = (new DbContextOptionsBuilder<WamaDbContext>())
                .UseInMemoryDatabase()
                .Options;

            using (var dbCtx = new WamaDbContext(InMemoryDbOption))
            {
                var usersJSONFile = "users.json";
                var users = JsonConvert.DeserializeObject<IEnumerable<UserAccount>>(File.ReadAllText(usersJSONFile));

                dbCtx.Database.EnsureDeleted();

                dbCtx.UserAccounts.AddRange(users);
                dbCtx.SaveChanges();
            }

            _UserAccountService = new UserAccountService(new DummyDbContextProvider(InMemoryDbOption));
        }

        [Theory(DisplayName = "Create Users")]
        [InlineData(typeof(PatronUserAccountViewModel))]
        [InlineData(typeof(EmployeeUserAccountViewModel))]
        [InlineData(typeof(ManagerUserAccountViewModel))]
        [InlineData(typeof(AdministratorUserAccountViewModel))]
        [InlineData(typeof(MantainanceUserAccountViewModel))]
        public async Task CreateUserAsyncTest(Type type)
        {
            var user = Activator.CreateInstance(type) as UserAccountViewModel;
            user.MemberId = TEST_MEMBER_ID;
            await _UserAccountService.CreateUserAsync(user);

            var userViewModel = await _UserAccountService.GetUserAccountAsync(TEST_MEMBER_ID);

            Assert.Equal(TEST_MEMBER_ID, userViewModel.MemberId);
        }

        [Theory(DisplayName = "Get a single UserAccount")]
        [InlineData("8521473", "Elton")]
        [InlineData("6325149", "Atencio")]
        [InlineData("2016546", "Patenaude")]
        [InlineData("6780655", "Adelia")]
        public async Task GetUserAccountAsyncTest(string memberId, string expectedFirstName)
        {
            var user = await _UserAccountService.GetUserAccountAsync(memberId);
            Assert.Equal(expectedFirstName, user.FirstName);
        }

        [Theory(DisplayName = "Get UserAccounts")]
        [InlineData(UserAccountType.Administrator, 10)]
        [InlineData(UserAccountType.Employee, 10)]
        [InlineData(UserAccountType.Manager, 10)]
        [InlineData(UserAccountType.Patron, 10)]
        [InlineData(UserAccountType.Mantainance, 2)]
        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
        {
            var users = await _UserAccountService.GetUserAccountsAsync(accountType);
            Assert.Equal(expectedCount, users.Count());
        }

        [Theory(DisplayName = "Get UserAccounts with filter")]
        [InlineData(UserAccountType.Administrator, 10)]
        [InlineData(UserAccountType.Employee, 10)]
        [InlineData(UserAccountType.Manager, 10)]
        [InlineData(UserAccountType.Patron, 10)]
        public async Task GetUserAccountsAsyncFTest(UserAccountType accountType, int expectedCount)
        {
            var filter = new UserSearchFilterViewModel
            {
                AccountTypes = new UserAccountType[] { accountType }
            };

            var users = await _UserAccountService.GetUserAccountsAsync(filter);
            Assert.Equal(expectedCount, users.Count());
        }


        [Theory(DisplayName = "Get suspended UserAccounts")]
        [InlineData(UserAccountType.Administrator, 0)]
        [InlineData(UserAccountType.Employee, 0)]
        [InlineData(UserAccountType.Manager, 0)]
        [InlineData(UserAccountType.Patron, 0)]
        public async Task GetSuspendedUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
        {
            var users = await _UserAccountService.GetSuspendedUserAccountsAsync(accountType);
            Assert.Equal(expectedCount, users.Count());
        }

        [Fact]
        public async Task GetPendingUserAccountsAsyncTest()
        {
            await Task.Delay(1);
        }

        [Fact]
        public async Task GetListservDataAsyncTest()
        {
            await Task.Delay(1);
        }

        [Fact]
        public async Task UpdateUserAccountAsyncTest()
        {
            await Task.Delay(1);
        }

        [Fact]
        public async Task SuspendUserAccountAsyncTest()
        {
            await Task.Delay(1);
        }

        [Fact]
        public async Task ReactivateUserAccountAsyncTest()
        {
            await Task.Delay(1);
        }

        [Fact]
        public async Task ApproveAccountAsyncTest()
        {
            await Task.Delay(1);
        }
    }
}