using WAMA.Core.Models.POCOs;

namespace WAMA.Core.Models.Service
{
    internal interface ICheckInService
    {
        LoginCredential GetLoginCredential(string memberId);
    }
}