using System;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Service;

namespace WAMA.Core.Services
{
    public class UserAccountService : IUserAccountService
    {
        public void CreateUser(UserAccount userAccount)
        {
            Task.Run(async () =>
            {
                await CreateUserAsync(userAccount);
            });
        }

        public async Task CreateUserAsync(UserAccount userAccount)
        {
            using (var dbCtx = new WamaDbContext())
            {
                dbCtx.UserAccounts.Add(userAccount);
                await dbCtx.SaveChangesAsync();
            }
        }

        public UserAccount GetUserAccount(string memberId)
        {
            return Task.Run(async () =>
            {
                return await GetUserAccountAsync(memberId);
            }).Result;
        }

        public async Task<UserAccount> GetUserAccountAsync(string memberId)
        {
            using (var dbCtx = new WamaDbContext())
            {
                return await dbCtx.UserAccounts.FindAsync(memberId);
            }
        }

        public void UpdateUserAccount(UserAccount updated)
        {
            Task.Run(async () =>
            {
                await UpdateUserAccountAsync(updated);
            });
        }

        public async Task UpdateUserAccountAsync(UserAccount updated)
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