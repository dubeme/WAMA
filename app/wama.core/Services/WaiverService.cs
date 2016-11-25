using System;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Extensions;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Services
{
    public class WaiverService : IWaiverService
    {
        private IDbContextProvider _DbCtxProvider;

        public WaiverService(IDbContextProvider dbCtx)
        {
            _DbCtxProvider = dbCtx;
        }

        public void AddWaiver(WaiverViewModel waiver)
        {
            Task.Run(async () =>
            {
                await AddWaiverAsync(waiver);
            });
        }

        public async Task AddWaiverAsync(WaiverViewModel waiver)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                await dbCtx.Waivers.AddAsync(waiver.ToDTO());
            }
        }

        public WaiverViewModel GetWaiver(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return dbCtx.Waivers.FirstOrDefault(wv => wv.MemberId == memberId).ToViewModel();
            }
        }

        public Task<WaiverViewModel> GetWaiverAsync(string memberId)
        {
            throw new NotImplementedException();
        }
    }
}