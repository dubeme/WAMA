using System;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public class MantainanceUserAccountViewModel : UserAccountViewModel
    {
        public new UserAccountType AccountType { get; } = UserAccountType.Mantainance;

        public override UserAccount ToUserAccount()
        {
            throw new NotImplementedException();
        }
    }
}