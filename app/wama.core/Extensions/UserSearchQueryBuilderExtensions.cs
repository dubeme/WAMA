using LinqKit;
using System.Collections.Generic;
using System.Linq;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel;

namespace WAMA.Core.Extensions
{
    public static class UserSearchQueryBuilderExtensions
    {
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

        private static IQueryable<UserAccount> AppendNameQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            var name = filter.Name;

            if (string.IsNullOrWhiteSpace(name))
            {
                return userAccounts;
            }

            return userAccounts.Where(account => account.FirstName.Contains(name) || account.LastName.Contains(name) || account.MiddleName.Contains(name));
        }

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

        private static IQueryable<UserAccount> AppendSuspensionStatusQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (Equals(filter.AccountIsSuspended, null))
            {
                return userAccounts;
            }

            return userAccounts.Where(account => account.IsSuspended == filter.AccountIsSuspended);
        }

        private static IQueryable<UserAccount> AppendApprovalStatusQuery(this IQueryable<UserAccount> userAccounts, UserSearchFilterViewModel filter)
        {
            if (Equals(filter.AccountIsApproved, null))
            {
                return userAccounts;
            }

            return userAccounts.Where(account => account.HasBeenApproved == filter.AccountIsApproved);
        }

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
                        cert.CertifiedOn >= filter.CertifiedAfter &&
                        cert.CertifiedOn <= filter.CertifiedBefore));
            }
            else if (Equals(filter.CertifiedAfter, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Certifications.Any(cert =>
                        cert.CertifiedOn >= filter.CertifiedAfter));
            }
            else if (Equals(filter.CertifiedBefore, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Certifications.Any(cert =>
                        cert.CertifiedOn <= filter.CertifiedBefore));
            }

            return userAccounts.Where(account =>
                account.Certifications.Any(certification =>
                    certification.CertifiedOn == filter.CertifiedOn));
        }

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
                        waiver.SignedOn >= filter.SignedWaiverAfter &&
                        waiver.SignedOn <= filter.SignedWaiverBefore));
            }
            else if (Equals(filter.SignedWaiverAfter, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Waivers.Any(waiver =>
                        waiver.SignedOn >= filter.SignedWaiverAfter));
            }
            else if (Equals(filter.SignedWaiverBefore, null) == false)
            {
                return userAccounts.Where(account =>
                    account.Waivers.Any(waiver =>
                        waiver.SignedOn <= filter.SignedWaiverBefore));
            }

            return userAccounts.Where(account =>
                account.Waivers.Any(waiver => 
                    waiver.SignedOn == filter.SignedWaiverOn));
        }
    }
}