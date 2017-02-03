using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    public static class CertificationExtensions
    {
        public static Certification ToDTO(this CertificationViewModel viewModel)
        {
            return new Certification
            {
                CertifiedOn = viewModel.CertifiedOn,
                ExpiresOn = viewModel.ExpiresOn,
                MemberId = viewModel.MemberId
            };
        }

        public static CertificationViewModel ToViewModel(this Certification dto)
        {
            return new CertificationViewModel
            {
                CertifiedOn = dto.CertifiedOn,
                ExpiresOn = dto.ExpiresOn,
                MemberId = dto.MemberId
            };
        }
    }
}