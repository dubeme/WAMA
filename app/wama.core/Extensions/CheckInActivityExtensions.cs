using System;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    public static class CheckInActivityExtensions
    {
        public static CheckInActivity ToDTO(this CheckInActivityViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public static CheckInActivityViewModel ToViewModel(this CheckInActivity dto)
        {
            return new CheckInActivityViewModel
            {
                CheckInDateTime = dto.CheckInDateTime,
                IsCheckedIn = dto.IsCheckedIn,
                MemberId = dto.MemberId,
                Member = dto.Member
            };
        }
    }
}