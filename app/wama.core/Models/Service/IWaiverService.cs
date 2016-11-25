using System.Threading.Tasks;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Models.Service
{
    internal interface IWaiverService
    {
        void AddWaiver(WaiverViewModel waiver);

        Task AddWaiverAsync(WaiverViewModel waiver);

        WaiverViewModel GetWaiver(string memberId);

        Task<WaiverViewModel> GetWaiverAsync(string memberId);
    }
}