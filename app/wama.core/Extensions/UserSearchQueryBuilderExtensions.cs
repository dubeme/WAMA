using LinqKit;
using System.Collections.Generic;
using System.Linq;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    /// <summary>
    /// Represents UserSearchQueryBuilderExtensions
    /// </summary>
    public static class UserSearchQueryBuilderExtensions
    {
        /// <summary>
        /// Appends the filter query.
        /// </summary>
        /// <param name="userAccounts">The user accounts.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static IQueryable<UserAccount> AppendFilterQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (Equals(filter, null))
            {
                return Enumerable.Empty<UserAccount>().AsQueryable();
            }

            return userAccounts.AppendNameQuery(filter)
                .AppendMemberIdsQuery(filter)
                .AppendAccountTypesQuery(filter)
                .AppendSuspensionStatusQuery(filter)
                .AppendApprovalStatusQuery(filter)
                .AppendCertificationDateQuery(filter)
                .AppendWaiverSignedDateQuery(filter);
        }

        /// <summary>
        /// Appends the name query.
        /// </summary>
        /// <param name="userAccounts">The user accounts.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private static IQueryable<UserAccount> AppendNameQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            var name = filter.Name;

            if (string.IsNullOrWhiteSpace(name))
            {
                return userAccounts;
            }

            return userAccounts.Where(account => account.FirstName.Contains(name) || account.LastName.Contains(name) || account.MiddleName.Contains(name));
        }

        /// <summary>
        /// Appends the member ids query.
        /// </summary>
        /// <param name="userAccounts">The user accounts.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private static IQueryable<UserAccount> AppendMemberIdsQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (Equals(filter.MemberIDs, null) || filter.MemberIDs.Any() == false)
            {
                return userAccounts;
            }

            var predicate = PredicateBuilder.New<UserAccount>();

            foreach (var id in filter.MemberIDs.Distinct().Select(id => id.Trim()))
            {
                var _id = id;
                predicate = predicate.Or(account => account.MemberId.Contains(_id));
            }

            return userAccounts.Where(predicate);
        }

        /// <summary>
        /// Appends the account types query.
        /// </summary>
        /// <param name="userAccounts">The user accounts.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private static IQueryable<UserAccount> AppendAccountTypesQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (Equals(filter.AccountTypes, null) || filter.AccountTypes.Any() == false)
            {
                return userAccounts;
            }

            var predicate = PredicateBuilder.New<UserAccount>();

            foreach (var actType in filter.AccountTypes.Distinct())
            {
                var _actType = actType;
                predicate = predicate.Or(account => account.AccountType == _actType);
            }

            return userAccounts.Where(predicate);
        }

        /// <summary>
        /// Appends the suspension status query.
        /// </summary>
        /// <param name="userAccounts">The user accounts.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private static IQueryable<UserAccount> AppendSuspensionStatusQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (filter.AccountIsSuspended)
            {
                return userAccounts.Where(account => account.IsSuspended);
            }

            return userAccounts;
        }

        /// <summary>
        /// Appends the approval status query.
        /// </summary>
        /// <param name="userAccounts">The user accounts.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private static IQueryable<UserAccount> AppendApprovalStatusQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (filter.AccountIsApproved)
            {
                return userAccounts.Where(account => account.HasBeenApproved);
            }

            return userAccounts;
        }

        /// <summary>
        /// Appends the certification date query.
        /// </summary>
        /// <param name="userAccounts">The user accounts.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private static IQueryable<UserAccount> AppendCertificationDateQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (Equals(filter.CertifiedOn, null) && Equals(filter.CertifiedAfter, null) && Equals(filter.CertifiedBefore, null))
            {
                return userAccounts;
            }
            else if (Equals(filter.CertifiedAfter, null) == false && Equals(filter.CertifiedBefore, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Certifications.Any(cert =>
                        cert.CertifiedOn >= filter.CertifiedAfter.Value.Date &&
                        cert.CertifiedOn <= filter.CertifiedBefore.Value.Date));
            }
            else if (Equals(filter.CertifiedAfter, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Certifications.Any(cert =>
                        cert.CertifiedOn >= filter.CertifiedAfter.Value.Date));
            }
            else if (Equals(filter.CertifiedBefore, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Certifications.Any(cert =>
                        cert.CertifiedOn <= filter.CertifiedBefore.Value.Date));
            }

            return userAccounts.Where(account =>
                account.Certifications.Any(certification =>
                    certification.CertifiedOn == filter.CertifiedOn.Value.Date));
        }

        /// <summary>
        /// Appends the waiver signed date query.
        /// </summary>
        /// <param name="userAccounts">The user accounts.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        private static IQueryable<UserAccount> AppendWaiverSignedDateQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (Equals(filter.SignedWaiverOn, null) && Equals(filter.SignedWaiverAfter, null) && Equals(filter.SignedWaiverBefore, null))
            {
                return userAccounts;
            }
            else if (Equals(filter.SignedWaiverAfter, null) == false && Equals(filter.SignedWaiverBefore, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Waivers.Any(waiver =>
                        waiver.SignedOn >= filter.SignedWaiverAfter.Value.Date &&
                        waiver.SignedOn <= filter.SignedWaiverBefore.Value.Date));
            }
            else if (Equals(filter.SignedWaiverAfter, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Waivers.Any(waiver =>
                        waiver.SignedOn >= filter.SignedWaiverAfter.Value.Date));
            }
            else if (Equals(filter.SignedWaiverBefore, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Waivers.Any(waiver =>
                        waiver.SignedOn <= filter.SignedWaiverBefore.Value.Date));
            }

            return userAccounts.Where(account =>
                account.Waivers.Any(waiver =>
                    waiver.SignedOn == filter.SignedWaiverOn.Value.Date));
        }
    }
}