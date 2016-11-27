﻿using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public class AdministratorUserAccountViewModel : UserAccountViewModel
    {
        public new UserAccountType AccountType { get; } = UserAccountType.Administrator;
    }
}