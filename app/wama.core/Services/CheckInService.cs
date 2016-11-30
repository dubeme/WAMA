using System;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Services
{
    public class CheckInService : ICheckInService
    {
        private IDbContextProvider _DbCtxProvider;

        public CheckInService(IDbContextProvider dbCtx)
        {
            _DbCtxProvider = dbCtx;
        }

        public void CreateLogInCredential(UserAccountViewModel user)
        {
            throw new NotImplementedException();
        }

        public async Task CreateLogInCredentialAsync(UserAccountViewModel user)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                dbCtx.LogInCredentials.Add(new LogInCredential
                {
                    MemberId = user.MemberId,
                    RequiresPassword = user.AccountType != UserAccountType.Patron
                });
                await dbCtx.SaveChangesAsync();
            }
        }

        public LogInCredential GetLogInCredential(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return dbCtx.LogInCredentials.FirstOrDefault(lc => lc.MemberId == memberId);
            }
        }

        public Task<LogInCredential> GetLogInCredentialAsync(string memberId)
        {
            throw new NotImplementedException();
        }
    }
}