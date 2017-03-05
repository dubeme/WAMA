using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Extensions;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel;
using System.Collections.Generic;

namespace WAMA.Core.Services
{
    public class CertificationService : ICertificationService
    {
        private IDbContextProvider _DbCtxProvider;

        public CertificationService(IDbContextProvider dbCtx)
        {
            _DbCtxProvider = dbCtx;
        }

        public async Task AddCertificationAsync(CertificationViewModel certification)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                await dbCtx.Certifications.AddAsync(certification.ToDTO());
                await dbCtx.SaveChangesAsync();
            }
        }

        public Task DeleteCertificationAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<CertificationViewModel> GetCertificationAsync(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                var certification = await dbCtx.Certifications
                    .FirstOrDefaultAsync(cert => cert.MemberId == memberId);

                return certification?.ToViewModel();
            }
        }

        public async Task<IEnumerable<CertificationViewModel>> GetCertificationsAsync(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return await dbCtx.Certifications
                    .Where(certification => certification.MemberId == memberId)
                    .Select(certification => certification.ToViewModel())
                    .ToListAsync();
            }
        }

        public async Task UpdateCertificationAsync(CertificationViewModel updated)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                var old = dbCtx.Certifications
                    .FirstOrDefaultAsync(cert => cert.MemberId == updated.MemberId);

                if (old == null)
                {
                    throw new InvalidOperationException("No certification found to update");
                }

                dbCtx.Entry(old).CurrentValues.SetValues(updated.ToDTO());
                await dbCtx.SaveChangesAsync();
            }
        }
    }
}