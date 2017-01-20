using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Provider;
using WAMA.Core.Models.Service;
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

        public void CreateLogInCredential(UserAccountViewModel user)
        {
            throw new NotImplementedException();
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

        public async Task<IEnumerable<CheckInActivity>> GetCheckInActivitiesForMemberAsync(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return await dbCtx.CheckInActivities
                    .Where(ci => ci.MemberId == memberId)
                    .ToListAsync();
            }
        }

        public async Task<IEnumerable<CheckInActivity>> GetCheckInActivitiesForPeriodAsync(DateTimeOffset start)
        {
            return await GetCheckInActivitiesForPeriodAsync(start, DateTimeOffset.MaxValue);
        }

        public async Task<IEnumerable<CheckInActivity>> GetCheckInActivitiesForPeriodAsync(DateTimeOffset start, DateTimeOffset end)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return await dbCtx.CheckInActivities
                    .Where(ci => ci.CheckInDateTime >= start && ci.CheckInDateTime <= end)
                    .ToListAsync();
            }
        }

        public LogInCredential GetLogInCredential(string memberId)
        {
            using (var dbCtx = _DbCtxProvider.GetWamaDbContext())
            {
                return dbCtx.LogInCredentials.FirstOrDefault(lc => lc.MemberId == memberId);
            }
        }

        public Task<LogInCredential> GetLogInCredentialAsync(string memberId)
        {
            throw new NotImplementedException();
        }

        public CheckInActivity PerformCheckIn(string memberId)
        {
            throw new NotImplementedException();
        }

        public async Task<CheckInActivity> PerformCheckInAsync(string memberId)
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

            return checkinActivity;
        }
    }
}