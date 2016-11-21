using System;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public class PatronUserAccountViewModel : UserAccountViewModel
    {
        public new UserAccountType AccountType { get; } = UserAccountType.Patron;

        public override UserAccount ToUserAccount()
        {
            throw new NotImplementedException();
        }
    }
}