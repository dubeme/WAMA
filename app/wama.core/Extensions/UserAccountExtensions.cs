using System;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Extensions
{
    /// <summary>
    /// Represents UserAccountExtensions
    /// </summary>
    public static class UserAccountExtensions
    {
        /// <summary>
        /// Converts the ViewModel to DTO.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public static UserAccount ToDTO(this UserAccountViewModel user)
        {
            return new UserAccount
            {
                AccountType = user.AccountType,
                Email = user.Email,
                FirstName = user.FirstName,
                Gender = user.Gender,
                HasBeenApproved = user.HasBeenApproved,
                InstitutionAffiliation = user.InstitutionAffiliation,
                IsSuspended = user.IsSuspended,
                LastName = user.LastName,
                MemberId = user.MemberId,
                MiddleName = user.MiddleName
            };
        }

        /// <summary>
        /// Converts the DTO to ViewModel.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">
        /// User has an Unknown account type - user
        /// or
        /// User has an invalid account type - user
        /// </exception>
        public static UserAccountViewModel ToViewModel(this UserAccount user)
        {
            UserAccountViewModel userViewModel;

            switch (user.AccountType)
            {
                /*case UserAccountType.Unknown:
                    throw new ArgumentException("User has an Unknown account type", nameof(user));*/

                case UserAccountType.Patron:
                    userViewModel = new PatronUserAccountViewModel();
                    break;

                case UserAccountType.Employee:
                    userViewModel = new EmployeeUserAccountViewModel();
                    break;

                case UserAccountType.Manager:
                    userViewModel = new ManagerUserAccountViewModel();
                    break;

                case UserAccountType.Administrator:
                    userViewModel = new AdministratorUserAccountViewModel();
                    break;

                case UserAccountType.Mantainance:
                    userViewModel = new MantainanceUserAccountViewModel();
                    break;

                default:
                    throw new ArgumentException("User has an invalid account type", nameof(user));
            }

            userViewModel.Email = user.Email;
            userViewModel.FirstName = user.FirstName;
            userViewModel.Gender = user.Gender;
            userViewModel.HasBeenApproved = user.HasBeenApproved;
            userViewModel.InstitutionAffiliation = user.InstitutionAffiliation;
            userViewModel.IsSuspended = user.IsSuspended;
            userViewModel.LastName = user.LastName;
            userViewModel.MemberId = user.MemberId;
            userViewModel.MiddleName = user.MiddleName;

            return userViewModel;
        }
    }
}