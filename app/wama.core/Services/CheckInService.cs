using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Extensions;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Services
{
    public class CheckInService : ICheckInService
    {
        private IDbContextProvider _DbCtxProvider;

        public CheckInService(IDbContextProvider dbCtx)
        {
            _DbCtxProvider = dbCtx;
        }

        public async Task CreateLogInCredentialAsync(UserAccountViewModel user)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                dbCtx.LogInCredentials.Add(new LogInCredential
                {
                    MemberId = user.MemberId,
                    RequiresPassword = user.AccountType != UserAccountType.Patron
                });
                await dbCtx.SaveChangesAsync();
            }
        }

        public async Task<LogInCredentialViewModel> GetLogInCredentialAsync(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                var loginCredential = await dbCtx.LogInCredentials
                    .FirstOrDefaultAsync(lc => lc.MemberId == memberId);

                return loginCredential?.ToViewModel();
            }
        }

        public async Task<CheckInActivityViewModel> PerformCheckInAsync(string memberId)
        {
            var checkinActivity = new CheckInActivity
            {
                MemberId = memberId,
                CheckInDateTime = DateTimeOffset.Now,
                IsCheckedIn = true,
            };

            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                dbCtx.CheckInActivities.Add(checkinActivity);
                await dbCtx.SaveChangesAsync();
            }

            return checkinActivity?.ToViewModel();
        }

        public async Task<IEnumerable<CheckInActivityViewModel>> GetCheckInActivitiesForMemberAsync(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return await dbCtx.CheckInActivities
                    .Where(checkInActivity => checkInActivity.MemberId == memberId)
                    .Select(checkInActivity => checkInActivity.ToViewModel())
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<CheckInActivityViewModel>> GetCheckInActivitiesForPeriodAsync(DateTimeOffset start)
        {
            return await GetCheckInActivitiesForPeriodAsync(start, DateTimeOffset.MaxValue);
        }

        public async Task<IEnumerable<CheckInActivityViewModel>> GetCheckInActivitiesForPeriodAsync(DateTimeOffset start, DateTimeOffset end)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return await dbCtx.CheckInActivities
                    .Where(checkInActivity => checkInActivity.CheckInDateTime >= start && checkInActivity.CheckInDateTime <= end)
                    .Select(checkInActivity => checkInActivity.ToViewModel())
                    .ToListAsync();
            }
        }
    }
}