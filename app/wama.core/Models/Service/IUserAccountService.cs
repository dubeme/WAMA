using System.Collections.Generic;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Models.Service
{
    public interface IUserAccountService
    {
        Task CreateUserAsync(UserAccountViewModel userAccount);

        Task<UserAccountViewModel> GetUserAccountAsync(string memberId);

        Task<IEnumerable<UserAccountViewModel>> GetUserAccountsAsync(UserSearchFilterViewModel filter);

        Task<IEnumerable<UserAccountViewModel>> GetSuspendedUserAccountsAsync(UserAccountType type);

        Task<IEnumerable<UserAccountViewModel>> GetPendingUserAccountsAsync(UserAccountType type);

        Task<IEnumerable<ListservViewModel>> GetListservDataAsync(UserAccountType type);

        Task UpdateUserAccountAsync(UserAccountViewModel updated);

        Task SuspendUserAccountAsync(string memberId);

        Task ReactivateUserAccountAsync(string memberId);

        Task ApproveAccountAsync(string memberId);
    }
}