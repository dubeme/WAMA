using System.Collections.Generic;
using System.Threading.Tasks;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Models.Service
{
    /// <summary>
    /// API Contract for interacting with <see cref="DTOs.Certification"/> in the Database
    /// </summary>
    public interface ICertificationService
    {
        /// <summary>
        /// Adds the certification asynchronous.
        /// </summary>
        /// <param name="certification">The certification.</param>
        /// <returns></returns>
        Task AddCertificationAsync(CertificationViewModel certification);

        /// <summary>
        /// Updates the certification asynchronous.
        /// </summary>
        /// <param name="updated">The updated.</param>
        /// <returns></returns>
        Task UpdateCertificationAsync(CertificationViewModel updated);

        /// <summary>
        /// Gets the certification asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        Task<CertificationViewModel> GetCertificationAsync(string memberId);

        /// <summary>
        /// Gets the certifications asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<CertificationViewModel>> GetCertificationsAsync(string memberId);

        /// <summary>
        /// Deletes the certification asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        Task DeleteCertificationAsync(string memberId);
    }
}