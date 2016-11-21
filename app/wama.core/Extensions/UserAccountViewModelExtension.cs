using System;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;

namespace WAMA.Core.Extensions
{
    public static class UserAccountViewModelExtension
    {
        public static UserAccount ToUserAccountDTO(this UserAccountViewModel user)
        {
            return new UserAccount
            {
                AccountType = user.AccountType,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MemberId = user.MemberId
            };
        }

        public static UserAccountViewModel ToUserAccountViewModel(this UserAccount user)
        {
            UserAccountViewModel userViewModel;

            switch (user.AccountType)
            {
                case UserAccountType.Unknown:
                    throw new ArgumentException("User has an Unknown account type", nameof(user));

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

            userViewModel.FirstName = user.FirstName;
            userViewModel.LastName = user.LastName;
            userViewModel.MemberId = user.MemberId;

            return userViewModel;
        }
    }
}