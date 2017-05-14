//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using System.Collections.Generic;
//using System;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using WAMA.Core.Models;
//using WAMA.Core.Models.DTOs;
//using WAMA.Core.Services;
//using WAMA.Core.ViewModel;
//using WAMA.Core.ViewModel.User;
//using WAMAcut.Helpers;
//using Xunit;

//namespace WAMAcut.Services
//{
//    public class UserAccountServiceAdvancedSearchTests
//    {
//        private const int NUMBER_OF_USER_ACCOUNTS_IN_JSON_FILE = 42;
//        private const string TEST_MEMBER_ID = "1234567";

//        private DbContextOptions InMemoryDbOption;
//        private UserAccountService _UserAccountService;

//        private const string UsersJSONFile = "users.json";
//        private static IEnumerable<UserAccount> Users = JsonConvert.DeserializeObject<IEnumerable<UserAccount>>(
//            File.ReadAllText(UsersJSONFile));

//        public UserAccountServiceAdvancedSearchTests()
//        {
//            InMemoryDbOption = (new DbContextOptionsBuilder<WamaDbContext>())
//                .UseInMemoryDatabase()
//                .Options;

//            using (var dbCtx = new WamaDbContext(InMemoryDbOption))
//            {
//                dbCtx.Database.EnsureDeleted();

//                dbCtx.UserAccounts.AddRange(Users);
//                dbCtx.SaveChanges();
//            }

//            _UserAccountService = new UserAccountService(new DummyDbContextProvider(InMemoryDbOption));
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                AccountIsApproved = false,
//                AccountIsSuspended = false,
//                AccountTypes = false,
//                CertifiedAfter = false,
//                CertifiedBefore = false,
//                CertifiedOn = false,
//                CommaSeparatedMemberIDs = false,
//                MemberIDs = false,
//                Name = false,
//                SignedWaiverAfter = false,
//                SignedWaiverBefore = false,
//                SignedWaiverOn = false,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }

//        public async Task GetUserAccountsAsyncTest(UserAccountType accountType, int expectedCount)
//        {
//            var filter = new UserSearchFilterViewModel
//            {
//                SignedWaiverOn = DateTimeOffset.Now,
//            };

//            var users = await _UserAccountService.GetUserAccountsAsync(filter);
//            Assert.Equal(expectedCount, users.Count());
//        }
//    }
//}