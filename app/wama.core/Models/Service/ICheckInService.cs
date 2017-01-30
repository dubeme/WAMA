using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAMA.Core.ViewModel;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Models.Service
{
    public interface ICheckInService
    {
        Task CreateLogInCredentialAsync(UserAccountViewModel user);

        Task<LogInCredentialViewModel> GetLogInCredentialAsync(string memberId);

        Task<CheckInActivityViewModel> PerformCheckInAsync(string memberId);

        Task<IEnumerable<CheckInActivityViewModel>> GetCheckInActivitiesForMemberAsync(string memberId);

        Task<IEnumerable<CheckInActivityViewModel>> GetCheckInActivitiesForPeriodAsync(DateTimeOffset start);

        Task<IEnumerable<CheckInActivityViewModel>> GetCheckInActivitiesForPeriodAsync(DateTimeOffset start, DateTimeOffset end);
    }
}