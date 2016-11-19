using WAMA.Core.Models.POCOs;

namespace WAMA.Core.Models.Service
{
    public interface ICheckInService
    {
        LoginCredential GetLoginCredential(string memberId);
    }
}