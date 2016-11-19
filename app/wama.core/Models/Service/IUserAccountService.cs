using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.Models.Service
{
    public interface IUserAccountService
    {
        void CreateUser(UserAccount userAccount);

        UserAccount GetUserAccount(string memberId);

        void UpdateUserAccount(UserAccount updated);

        Task CreateUserAsync(UserAccount userAccount);

        Task<UserAccount> GetUserAccountAsync(string memberId);

        Task UpdateUserAccountAsync(UserAccount updated);
    }
}