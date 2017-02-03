using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    public static class WaiverExtensions
    {
        public static Waiver ToDTO(this WaiverViewModel viewModel)
        {
            return new Waiver
            {
                MemberId = viewModel.MemberId,
                SignedOn = viewModel.SignedOn
            };
        }

        public static WaiverViewModel ToViewModel(this Waiver dto)
        {
            return new WaiverViewModel
            {
                MemberId = dto.MemberId,
                SignedOn = dto.SignedOn
            };
        }
    }
}