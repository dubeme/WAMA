using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel;
using WAMA.Core.Extensions;
using System;

namespace WAMA.Core.Services
{
    public class CertificationService : ICertificationService
    {
        private IDbContextProvider _DbCtxProvider;

        public CertificationService(IDbContextProvider dbCtx)
        {
            _DbCtxProvider = dbCtx;
        }

        public void AddCertification(CertificationViewModel certification)
        {
            Task.Run(async () =>
            {
                await AddCertificationAsync(certification);
            });
        }

        public async Task AddCertificationAsync(CertificationViewModel certification)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                await dbCtx.Certifications.AddAsync(certification.ToDTO());
            }
        }

        public CertificationViewModel GetCertification(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return dbCtx.Certifications.SingleOrDefault(cert => cert.MemberId == memberId).ToViewModel();
            }
        }

        public Task<CertificationViewModel> GetCertificationAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCertification(CertificationViewModel updated)
        {
            Task.Run(async () =>
            {
                await UpdateCertificationAsync(updated);
            });
        }

        public async Task UpdateCertificationAsync(CertificationViewModel updated)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                var old = dbCtx.Certifications.SingleOrDefault(cert => cert.MemberId.Equals(updated.MemberId));

                if (old == null)
                {
                    throw new InvalidOperationException("No certification found to update");
                }

                dbCtx.Entry(old).CurrentValues.SetValues(updated);
                await dbCtx.SaveChangesAsync();
            }
        }
    }
}