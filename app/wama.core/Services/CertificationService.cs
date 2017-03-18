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
    /// <summary>
    /// Represents CertificationService
    /// </summary>
    /// <seealso cref="WAMA.Core.Models.Service.ICertificationService" />
    public class CertificationService : ICertificationService
    {
        /// <summary>
        /// The database context provider
        /// </summary>
        private IDbContextProvider _DbCtxProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificationService"/> class.
        /// </summary>
        /// <param name="dbCtx">The database CTX.</param>
        public CertificationService(IDbContextProvider dbCtx)
        {
            _DbCtxProvider = dbCtx;
        }

        /// <summary>
        /// Adds the certification asynchronous.
        /// </summary>
        /// <param name="certification">The certification.</param>
        /// <returns></returns>
        public async Task AddCertificationAsync(CertificationViewModel certification)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                await dbCtx.Certifications.AddAsync(certification.ToDTO());
                await dbCtx.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Deletes the certification asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task DeleteCertificationAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the certification asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        public async Task<CertificationViewModel> GetCertificationAsync(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                var certification = await dbCtx.Certifications
                    .FirstOrDefaultAsync(cert => cert.MemberId == memberId);

                return certification?.ToViewModel();
            }
        }

        /// <summary>
        /// Gets the certifications asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Updates the certification asynchronous.
        /// </summary>
        /// <param name="updated">The updated.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">No certification found to update</exception>
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