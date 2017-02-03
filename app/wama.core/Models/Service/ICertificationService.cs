using System.Threading.Tasks;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Models.Service
{
    public interface ICertificationService
    {
        Task AddCertificationAsync(CertificationViewModel certification);

        Task UpdateCertificationAsync(CertificationViewModel updated);

        Task<CertificationViewModel> GetCertificationAsync(string memberId);
    }
}