using System.Linq;
using WAMA.Core.Models;
using WAMA.Core.Models.POCOs;
using WAMA.Core.Models.Service;

namespace WAMA.Core.Services
{
    public class CheckInService : ICheckInService
    {
        public LoginCredential GetLoginCredential(string id)
        {
            using (var dbCtx = new WamaDbContext())
            {
                return dbCtx.LoginCredentials.First(lc => lc.UserId == id);
            }
        }
    }
}