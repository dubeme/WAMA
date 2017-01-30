using System.Collections.Generic;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Models.Service
{
    public interface IUserAccountService
    {
        void CreateUser(UserAccountViewModel userAccount);

        Task CreateUserAsync(UserAccountViewModel userAccount);

        UserAccountViewModel GetUserAccount(string memberId);

        Task<UserAccountViewModel> GetUserAccountAsync(string memberId);

        Task<IEnumerable<UserAccountViewModel>> GetUserAccountsAsync(UserAccountType type);

        void UpdateUserAccount(UserAccountViewModel updated);

        Task UpdateUserAccountAsync(UserAccountViewModel updated);

        // void DeleteUserAccount();
    }
}