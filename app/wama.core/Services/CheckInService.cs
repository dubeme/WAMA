using System;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;

namespace WAMA.Core.Services
{
    public class CheckInService : ICheckInService
    {
        private IDbContextProvider _DbCtxProvider;

        public CheckInService(IDbContextProvider dbCtx)
        {
            _DbCtxProvider = dbCtx;
        }

        public LogInCredential GetLogInCredential(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return dbCtx.LogInCredentials.FirstOrDefault(lc => lc.UserId == memberId);
            }
        }

        public Task<LogInCredential> GetLogInCredentialAsync(string memberId)
        {
            throw new NotImplementedException();
        }
    }
}