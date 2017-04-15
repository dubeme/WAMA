using System;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    /// <summary>
    /// Represents CheckInActivityExtensions
    /// </summary>
    public static class CheckInActivityExtensions
    {
        /// <summary>
        /// Converts the ViewModel to DTO.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static CheckInActivity ToDTO(this CheckInActivityViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the DTO to ViewModel.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public static CheckInActivityViewModel ToViewModel(this CheckInActivity dto)
        {
            return new CheckInActivityViewModel
            {
                CheckInDateTime = dto.CheckInDateTime.LocalDateTime,
                IsCheckedIn = dto.IsCheckedIn,
                MemberId = dto.MemberId,
                Member = dto.Member
            };
        }
    }
}