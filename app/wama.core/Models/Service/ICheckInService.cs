using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Models.Service
{
    public interface ICheckInService
    {
        void CreateLogInCredential(UserAccountViewModel user);

        Task CreateLogInCredentialAsync(UserAccountViewModel user);

        LogInCredential GetLogInCredential(string memberId);

        Task<LogInCredential> GetLogInCredentialAsync(string memberId);
    }
}