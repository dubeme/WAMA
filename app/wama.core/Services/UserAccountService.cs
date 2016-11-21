using System;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models;
using WAMA.Core.Extensions;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Services
{
    public class UserAccountService : IUserAccountService
    {
        public void CreateUser(UserAccountViewModel userAccount)
        {
            Task.Run(async () =>
            {
                await CreateUserAsync(userAccount);
            });
        }

        public async Task CreateUserAsync(UserAccountViewModel userAccount)
        {
            using (var dbCtx = new WamaDbContext())
            {
                dbCtx.UserAccounts.Add(userAccount.ToUserAccountDTO());
                await dbCtx.SaveChangesAsync();
            }
        }

        public UserAccountViewModel GetUserAccount(string memberId)
        {
            return Task.Run(async () =>
            {
                return await GetUserAccountAsync(memberId);
            }).Result;
        }

        public async Task<UserAccountViewModel> GetUserAccountAsync(string memberId)
        {
            using (var dbCtx = new WamaDbContext())
            {
                return (await dbCtx.UserAccounts.FindAsync(memberId)).ToUserAccountViewModel();
            }
        }

        public void UpdateUserAccount(UserAccountViewModel updated)
        {
            Task.Run(async () =>
            {
                await UpdateUserAccountAsync(updated);
            });
        }

        public async Task UpdateUserAccountAsync(UserAccountViewModel updated)
        {
            using (var dbCtx = new WamaDbContext())
            {
                var old = dbCtx.UserAccounts.SingleOrDefault(user => user.MemberId.Equals(updated.MemberId));

                if (old == null)
                {
                    throw new InvalidOperationException("No user account updated");
                }

                dbCtx.Entry(old).CurrentValues.SetValues(updated);
                await dbCtx.SaveChangesAsync();
            }
        }
    }
}