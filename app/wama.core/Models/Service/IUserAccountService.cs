using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Models.Service
{
    public interface IUserAccountService
    {
        void CreateUser(UserAccountViewModel userAccount);

        UserAccountViewModel GetUserAccount(string memberId);

        void UpdateUserAccount(UserAccountViewModel updated);

        Task CreateUserAsync(UserAccountViewModel userAccount);

        Task<UserAccountViewModel> GetUserAccountAsync(string memberId);

        Task UpdateUserAccountAsync(UserAccountViewModel updated);
    }
}