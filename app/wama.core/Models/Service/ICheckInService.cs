using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Models.Service
{
    public interface ICheckInService
    {
        void CreateLogInCredential(UserAccountViewModel user);

        Task CreateLogInCredentialAsync(UserAccountViewModel user);

        LogInCredential GetLogInCredential(string memberId);

        Task<LogInCredential> GetLogInCredentialAsync(string memberId);

        CheckInActivity PerformCheckIn(string memberId);

        Task<CheckInActivity> PerformCheckInAsync(string memberId);

        Task<IEnumerable<CheckInActivity>> GetCheckInActivitiesForMemberAsync(string memberId);

        Task<IEnumerable<CheckInActivity>> GetCheckInActivitiesForPeriodAsync(DateTimeOffset start);

        Task<IEnumerable<CheckInActivity>> GetCheckInActivitiesForPeriodAsync(DateTimeOffset start, DateTimeOffset end);
    }
}