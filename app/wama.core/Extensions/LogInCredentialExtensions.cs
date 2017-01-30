using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    public static class LogInCredentialExtensions
    {
        public static LogInCredential ToDTO(this LogInCredentialViewModel viewModel)
        {
            return new LogInCredential
            {
                MemberId = viewModel.MemberId,
                Password = viewModel.Password,
                RequiresPassword = viewModel.RequiresPassword
            };
        }

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