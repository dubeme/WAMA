using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    /// <summary>
    /// Represents CertificationExtensions
    /// </summary>
    public static class CertificationExtensions
    {
        /// <summary>
        /// Converts the ViewModel to DTO.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public static Certification ToDTO(this CertificationViewModel viewModel)
        {
            return new Certification
            {
                CertifiedOn = viewModel.CertifiedOn.Date,
                ExpiresOn = viewModel.ExpiresOn.Date,
                MemberId = viewModel.MemberId,
                Type = viewModel.Type
            };
        }

        /// <summary>
        /// Converts the DTO to ViewModel.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <returns></returns>
        public static CertificationViewModel ToViewModel(this Certification dto)
        {
            return new CertificationViewModel
            {
                CertifiedOn = dto.CertifiedOn.Date,
                ExpiresOn = dto.ExpiresOn.Date,
                MemberId = dto.MemberId,
                Type = dto.Type
            };
        }
    }
}