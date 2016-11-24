using System.Linq;
using WAMA.Core.Models;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Service;

namespace WAMA.Core.Services
{
    public class CheckInService : ICheckInService
    {
        public LogInCredential GetLogInCredential(string memberId)
        {
            using (var dbCtx = new WamaDbContext())
            {
                return dbCtx.LogInCredentials.FirstOrDefault(lc => lc.UserId == memberId);
            }
        }
    }
}