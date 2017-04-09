using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;
using WAMA.Web;
using WAMAcut.Helpers;
using Xunit;

using static WAMA.Web.Controllers.WamaBaseController;

namespace WAMAcut.System.Tests
{
    public class EditUserAccountViaUserTool : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        private const string TESTING_MEMBER_ID = "8833550";
        private const string ANOTHER_TESTING_MEMBER_ID = "0133550";
        private const string EDIT_ACCOUNT_URL = "/adminconsole/usertool/editaccount";

        public EditUserAccountViaUserTool(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;

            using (var dbCtx = DummyDbContextProvider.GetSqlServerDbOption())
            {
                dbCtx.UserAccounts.RemoveRange(dbCtx.UserAccounts.Where(user => user.MemberId == TESTING_MEMBER_ID));
                dbCtx.SaveChanges();

                dbCtx.UserAccounts.Add(new UserAccount
                {
                    AccountType = UserAccountType.Unknown,
                    MemberId = TESTING_MEMBER_ID,
                    FirstName = "admin-first-name",
                    LastName = "admin-last-name",
                    Email = "admin@email.edu",
                    Gender = Gender.Unknown,
                    InstitutionAffiliation = InstitutionAffiliation.Unknown
                });

                dbCtx.SaveChanges();
            }
        }

        [Theory(DisplayName = "Edit user account")]
        [InlineData(
            typeof(PatronUserAccountViewModel),
            TESTING_MEMBER_ID,
            "paul",
            "jim",
            "paul.jim@sdstate.edu",
            Gender.Male,
            InstitutionAffiliation.Student)]
        public async Task EditUserAccount(
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
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.RequestToken)}", HashString(memberId)),
            });

            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);

            Assert.Equal($"/adminconsole/usertool/viewaccount?memberid={memberId}".ToLower(),
                response.Headers.Location.OriginalString.ToLower());

            using (var dbCtx = DummyDbContextProvider.GetSqlServerDbOption())
            {
                var userAccount = dbCtx.UserAccounts.First(user => user.MemberId == memberId);

                Assert.Equal(userAccountViewModel.AccountType, userAccount.AccountType);
                Assert.Equal(firstName, userAccount.FirstName);
                Assert.Equal(lastName, userAccount.LastName);
                Assert.Equal(email, userAccount.Email);
                Assert.Equal(gender, userAccount.Gender);
                Assert.Equal(affiliation, userAccount.InstitutionAffiliation);
            }
        }

        [Fact(DisplayName = "Edit user account without member ID")]
        public async Task EditUserAccountWithoutMemberId()
        {
            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>(
                    $"{nameof(UserAccountViewModel.InstitutionAffiliation)}",
                    $"{InstitutionAffiliation.Faculty}"),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.RequestToken)}", string.Empty),
            });

            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(EDIT_ACCOUNT_URL, response.RequestMessage.RequestUri.AbsolutePath.ToLower());
        }

        [Fact(DisplayName = "Edit user account without a member ID and request token")]
        public async Task EditUserAccountWithoutMemberIdAndRequestToken()
        {
            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.InstitutionAffiliation)}", $"{Gender.Male}"),
            });

            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(EDIT_ACCOUNT_URL, response.RequestMessage.RequestUri.AbsolutePath.ToLower());
        }

        [Fact(DisplayName = "Edit user account without request token")]
        public async Task EditUserAccountWithoutRequestToken()
        {
            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.MemberId)}", $"{TESTING_MEMBER_ID}"),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.AccountType)}", $"{UserAccountType.Patron}"),
            });

            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(EDIT_ACCOUNT_URL, response.RequestMessage.RequestUri.AbsolutePath.ToLower());

            using (var dbCtx = DummyDbContextProvider.GetSqlServerDbOption())
            {
                var userAccount = dbCtx.UserAccounts.First(user => user.MemberId == TESTING_MEMBER_ID);

                Assert.NotEqual(UserAccountType.Patron, userAccount.AccountType);
            }
        }

        [Fact(DisplayName = "Edit account using a request token set to null")]
        public async Task EditUserAccountWithRequestTokenNull()
        {
            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.MemberId)}", $"{TESTING_MEMBER_ID}"),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.RequestToken)}", null),
            });

            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(EDIT_ACCOUNT_URL, response.RequestMessage.RequestUri.AbsolutePath.ToLower());

            // TODO: assert exception string for specific string
            // var content = await response.Content.ReadAsStringAsync();
        }

        [Fact(DisplayName = "Edit account using a request token set to an empty string")]
        public async Task EditUserAccountWithRequestTokenEmptyString()
        {
            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.MemberId)}", $"{TESTING_MEMBER_ID}"),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.RequestToken)}", string.Empty),
            });

            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(EDIT_ACCOUNT_URL, response.RequestMessage.RequestUri.AbsolutePath.ToLower());
        }

        [Fact(DisplayName = "Edit account using a request token set to an white spaces")]
        public async Task EditUserAccountWithRequestTokenWhiteSpaces()
        {
            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.MemberId)}", $"{TESTING_MEMBER_ID}"),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.RequestToken)}", new string('\0', 7)),
            });

            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(EDIT_ACCOUNT_URL, response.RequestMessage.RequestUri.AbsolutePath.ToLower());
        }

        [Fact(DisplayName = "Edit account using a request token not meant for the current member ID")]
        public async Task EditUserAccountWithRequestTokenOtherID()
        {
            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.MemberId)}", $"{TESTING_MEMBER_ID}"),
                new KeyValuePair<string, string>($"{nameof(UserAccountViewModel.RequestToken)}", HashString(ANOTHER_TESTING_MEMBER_ID)),
            });

            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
            Assert.Equal(EDIT_ACCOUNT_URL, response.RequestMessage.RequestUri.AbsolutePath.ToLower());
        }

        [Fact]
        public async Task EditUserAccountWithEmptyPayload()
        {
            var payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
            var response = await _client.PostAsync(EDIT_ACCOUNT_URL, payload);

            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}