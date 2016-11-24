using WAMA.Core.Models.DTOs;

namespace WAMA.Core.Models.Service
{
    public interface ICheckInService
    {
        LogInCredential GetLogInCredential(string memberId);
    }
}