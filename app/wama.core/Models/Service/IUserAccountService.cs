using System.Collections.Generic;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Models.Service
{
    /// <summary>
    /// API Contract for interacting with <see cref="DTOs.UserAccount"/> in the Database
    /// </summary>
    public interface IUserAccountService
    {
        /// <summary>
        /// Creates the user asynchronous.
        /// </summary>
        /// <param name="userAccount">The user account.</param>
        /// <returns></returns>
        Task CreateUserAsync(UserAccountViewModel userAccount);

        /// <summary>
        /// Gets the user account asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        Task<UserAccountViewModel> GetUserAccountAsync(string memberId);

        /// <summary>
        /// Gets the user accounts asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        Task<IEnumerable<UserAccountViewModel>> GetUserAccountsAsync(UserSearchFilterViewModel filter);

        /// <summary>
        /// Gets the suspended user accounts asynchronous.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        Task<IEnumerable<UserAccountViewModel>> GetSuspendedUserAccountsAsync(UserAccountType type);

        /// <summary>
        /// Gets the pending user accounts asynchronous.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        Task<IEnumerable<UserAccountViewModel>> GetPendingUserAccountsAsync(UserAccountType type);

        /// <summary>
        /// Gets the listserv data asynchronous.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        Task<IEnumerable<ListservViewModel>> GetListservDataAsync(UserAccountType type);

        /// <summary>
        /// Updates the user account asynchronous.
        /// </summary>
        /// <param name="updated">The updated.</param>
        /// <returns></returns>
        Task UpdateUserAccountAsync(UserAccountViewModel updated);

        /// <summary>
        /// Suspends the user account asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        Task SuspendUserAccountAsync(string memberId);

        /// <summary>
        /// Reactivates the user account asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        Task ReactivateUserAccountAsync(string memberId);

        /// <summary>
        /// Approves the account asynchronous.
        /// </summary>
        /// <param name="memberId">The member identifier.</param>
        /// <returns></returns>
        Task ApproveAccountAsync(string memberId);

        /// <summary>
        /// Gets the overall activity aggregates asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<AdminConsoleHomeViewModel> GetOverallActivityAggregatesAsync();
    }
}