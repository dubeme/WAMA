using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Extensions;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Services
{
    public class UserAccountService : IUserAccountService
    {
        private IDbContextProvider _DbCtxProvider;

        public UserAccountService(IDbContextProvider dbCtx)
        {
            _DbCtxProvider = dbCtx;
        }

        public async Task CreateUserAsync(UserAccountViewModel userAccount)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                dbCtx.UserAccounts.Add(userAccount.ToDTO());
                await dbCtx.SaveChangesAsync();
            }
        }

        public async Task<UserAccountViewModel> GetUserAccountAsync(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                var userAccount = await dbCtx.UserAccounts
                    .FirstOrDefaultAsync(user => user.MemberId == memberId);

                return userAccount?.ToViewModel();
            }
        }

        public async Task<IEnumerable<UserAccountViewModel>> GetUserAccountsAsync(UserAccountType type)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return await dbCtx.UserAccounts
                    .Where(user => user.AccountType == type)
                    .Select(user => user.ToViewModel())
                    .ToListAsync();
            }
        }

        public async Task UpdateUserAccountAsync(UserAccountViewModel updated)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
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