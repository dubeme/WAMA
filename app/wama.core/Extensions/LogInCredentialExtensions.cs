using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    /// <summary>
    /// Represents LogInCredentialExtensions
    /// </summary>
    public static class LogInCredentialExtensions
    {
        /// <summary>
        /// Converts the ViewModel to DTO.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public static LogInCredential ToDTO(this LogInCredentialViewModel viewModel)
        {
            return new LogInCredential
            {
                MemberId = viewModel.MemberId,
                Password = viewModel.Password,
                RequiresPassword = viewModel.RequiresPassword
            };
        }

        /// <summary>
        /// Converts the DTO to ViewModel.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public static LogInCredentialViewModel ToViewModel(this LogInCredential dto)
        {
            return new LogInCredentialViewModel
            {
                MemberId = dto.MemberId,
                Password = dto.Password,
                RequiresPassword = dto.RequiresPassword
            };
        }
    }
}