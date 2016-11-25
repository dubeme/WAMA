using System.Threading.Tasks;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Models.Service
{
    internal interface ICertificationService
    {
        void AddCertification(CertificationViewModel certification);

        Task AddCertificationAsync(CertificationViewModel certification);

        void UpdateCertification(CertificationViewModel updated);

        Task UpdateCertificationAsync(CertificationViewModel updated);

        CertificationViewModel GetCertification(string memberId);

        Task<CertificationViewModel> GetCertificationAsync(string memberId);
    }
}