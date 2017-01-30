using Microsoft.EntityFrameworkCore;
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

        public async Task AddWaiverAsync(WaiverViewModel waiver)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                await dbCtx.Waivers.AddAsync(waiver.ToDTO());
            }
        }

        public async Task<WaiverViewModel> GetWaiverAsync(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                var waiver = await dbCtx.Waivers
                    .FirstOrDefaultAsync(wv => wv.MemberId == memberId);

                return waiver?.ToViewModel();
            }
        }
    }
}