using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WAMA.Core.Models;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;
using WAMA.Web;
using WAMAcut.Helpers;
using Xunit;

namespace WAMAcut.System.Tests
{
    public class CreateNewUserViaUserTool : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        private const string Patron_MEMBER_ID = "8888881";
        private const string Employee_MEMBER_ID = "8888882";
        private const string Manager_MEMBER_ID = "8888883";
        private const string Administrator_MEMBER_ID = "8888884";
        private const string Mantainance_MEMBER_ID = "8888885";

        public CreateNewUserViaUserTool(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;

            using (var dbCtx = DummyDbContextProvider.GetSqlServerDbOption())
            {
                dbCtx.UserAccounts.RemoveRange(dbCtx.UserAccounts.Where(user =>
                    user.MemberId == Patron_MEMBER_ID ||
                    user.MemberId == Employee_MEMBER_ID ||
                    user.MemberId == Manager_MEMBER_ID ||
                    user.MemberId == Administrator_MEMBER_ID ||
                    user.MemberId == Mantainance_MEMBER_ID
                ));

                dbCtx.SaveChanges();
            }
        }

        [Theory(DisplayName = "Create user accounts integration tests")]
        [InlineData(
            typeof(PatronUserAccountViewModel),
            Patron_MEMBER_ID,
            "paul",
            "jim",
            "paul.jim@sdstate.edu",
            Gender.Male,
            InstitutionAffiliation.Student)]
        [InlineData(
            typeof(EmployeeUserAccountViewModel),
            Employee_MEMBER_ID,
            "angela",
            "dong",
            "angela.dong@sdstate.edu",
            Gender.Male,
            InstitutionAffiliation.Student)]
        [InlineData(
            typeof(ManagerUserAccountViewModel),
            Manager_MEMBER_ID,
            "ada",
            "malik",
            "ada.malik@sdstate.edu",
            Gender.Male,
            InstitutionAffiliation.Student)]
        [InlineData(
            typeof(AdministratorUserAccountViewModel),
            Administrator_MEMBER_ID,
            "francis",
            "dioup",
            "francis.dioup@sdstate.edu",
            Gender.Male,
            InstitutionAffiliation.Student)]
        [InlineData(
            typeof(MantainanceUserAccountViewModel),
            Mantainance_MEMBER_ID,
            "ding",
            "dong",
            "ding.dong@sdstate.edu",
            Gender.Male,
            InstitutionAffiliation.Student)]
        public async Task CreateUserAccount(
            Type type,
            string memberId,
            string firstName,
            string lastName,
            string email,
            Gender gender,
            InstitutionAffiliation affiliation)
        {
            var userAccountViewModel = Activator.CreateInstance(type) as UserAccountViewModel;

            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.AccountType)}", $"{userAccountViewModel.AccountType}"),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.MemberId)}", memberId),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.FirstName)}", firstName),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.LastName)}", lastName),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.Email)}", email),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.Gender)}", $"{gender}"),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.InstitutionAffiliation)}", $"{affiliation}"),
            });

            var response = await _client.PostAsync("/adminconsole/usertool/CreateNewUserAccount", payload);

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);

            Assert.Equal($"/adminconsole/usertool/{userAccountViewModel.AccountType}s".ToLower(),
                response.Headers.Location.OriginalString.ToLower());

            using (var dbCtx = DummyDbContextProvider.GetSqlServerDbOption())
            {
                var userAccount = dbCtx.UserAccounts.First(user => user.MemberId == memberId);

                Assert.Equal(userAccountViewModel.AccountType, userAccount.AccountType);
                Assert.Equal(memberId, userAccount.MemberId);
                Assert.Equal(firstName, userAccount.FirstName);
                Assert.Equal(lastName, userAccount.LastName);
                Assert.Equal(email, userAccount.Email);
                Assert.Equal(gender, userAccount.Gender);
                Assert.Equal(affiliation, userAccount.InstitutionAffiliation);
            }
        }
    }
}