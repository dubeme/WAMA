using System.Threading.Tasks;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Models.Service
{
    public interface IWaiverService
    {
        Task AddWaiverAsync(WaiverViewModel waiver);

        Task<WaiverViewModel> GetWaiverAsync(string memberId);
    }
}