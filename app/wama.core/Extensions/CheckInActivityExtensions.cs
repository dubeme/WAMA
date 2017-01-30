using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    public static class CheckInActivityExtensions
    {
        public static CheckInActivity ToDTO(this CheckInActivityViewModel viewModel)
        {
            return new CheckInActivity
            {
                CheckInDateTime = viewModel.CheckInDateTime,
                IsCheckedIn = viewModel.IsCheckedIn,
                MemberId = viewModel.MemberId
            };
        }

        public static CheckInActivityViewModel ToViewModel(this CheckInActivity dto)
        {
            return new CheckInActivityViewModel
            {
                CheckInDateTime = dto.CheckInDateTime,
                IsCheckedIn = dto.IsCheckedIn,
                MemberId = dto.MemberId
            };
        }
    }
}