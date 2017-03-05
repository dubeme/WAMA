using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Extensions;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel;
using WAMA.Core.ViewModel.User;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public class UserToolController : WamaBaseController
    {
        private static Dictionary<UserAccountType, string> AccountTypeToolsMapping = new Dictionary<UserAccountType, string>
        {
            { UserAccountType.Patron, Constants.ADMIN_CONSOLE_USERS_PATRONS },
            { UserAccountType.Employee, Constants.ADMIN_CONSOLE_USERS_EMPLOYEES },
            { UserAccountType.Manager, Constants.ADMIN_CONSOLE_USERS_MANAGERS },
            { UserAccountType.Administrator, Constants.ADMIN_CONSOLE_USERS_ADMINISTRATORS}
        };


        private IUserAccountService _UserAccountService;
        private ICheckInService _CheckInService;

        public UserToolController(IUserAccountService userAccountService, ICheckInService checkinService)
        {
            _UserAccountService = userAccountService;
            _CheckInService = checkinService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["SuspendedAdministrator"] = await _UserAccountService.GetSuspendedUserAccountsAsync(UserAccountType.Administrator);
            ViewData["SuspendedManager"] = await _UserAccountService.GetSuspendedUserAccountsAsync(UserAccountType.Manager);
            ViewData["SuspendedEmployee"] = await _UserAccountService.GetSuspendedUserAccountsAsync(UserAccountType.Employee);
            ViewData["SuspendedPatron"] = await _UserAccountService.GetSuspendedUserAccountsAsync(UserAccountType.Patron);
            ViewData["PendingAdministrator"] = await _UserAccountService.GetPendingUserAccountsAsync(UserAccountType.Administrator);
            ViewData["PendingManager"] = await _UserAccountService.GetPendingUserAccountsAsync(UserAccountType.Manager);
            ViewData["PendingEmployee"] = await _UserAccountService.GetPendingUserAccountsAsync(UserAccountType.Employee);
            ViewData["PendingPatron"] = await _UserAccountService.GetPendingUserAccountsAsync(UserAccountType.Patron);

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Index.cshtml");
        }

        public async Task<IActionResult> Administrators()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(new UserSearchFilterViewModel
            {
                AccountTypes = new UserAccountType[] { UserAccountType.Administrator }
            });

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS_ADMINISTRATORS);
            ViewData[Constants.USER_ACCOUNT_TYPE] = AppString.AdministratorLabel;

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Administrators.cshtml", accounts);
        }

        public async Task<IActionResult> Employees()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(new UserSearchFilterViewModel
            {
                AccountTypes = new UserAccountType[] { UserAccountType.Employee }
            });

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS_EMPLOYEES);
            ViewData[Constants.USER_ACCOUNT_TYPE] = AppString.EmployeeLabel;

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Employees.cshtml", accounts);
        }

        public async Task<IActionResult> Managers()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(new UserSearchFilterViewModel
            {
                AccountTypes = new UserAccountType[] { UserAccountType.Manager }
            });

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS_MANAGERS);
            ViewData[Constants.USER_ACCOUNT_TYPE] = AppString.ManagerLabel;

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Managers.cshtml", accounts);
        }

        public async Task<IActionResult> Patrons()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(new UserSearchFilterViewModel
            {
                AccountTypes = new UserAccountType[] { UserAccountType.Patron }
            });

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS_PATRONS);
            ViewData[Constants.USER_ACCOUNT_TYPE] = AppString.PatronLabel;

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Patrons.cshtml", accounts);
        }

        public async Task<IActionResult> ViewAccount(string memberId)
        {
            var account = await _UserAccountService.GetUserAccountAsync(memberId);

            if (!Equals(account, null) && AccountTypeToolsMapping.ContainsKey(account.AccountType))
            {
                SetActiveConsoleTool(AccountTypeToolsMapping[account.AccountType]);
            }

            account.RequestToken = HashString(account.MemberId);

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/ViewAccount.cshtml", account);
        }

        public IActionResult UserAccountAddNewUser()
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/UserAccountAddNewUser.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> UserAccountAddNewUser(PatronUserAccountViewModel user)
        {
            if (!ModelState.IsValid)
            {
                this.SetErrorMessages(ModelState.Values
                    .Where(val => val.ValidationState == ModelValidationState.Invalid)
                    .Select(val => val.Errors.FirstOrDefault().ErrorMessage));
            }
            else
            {
                var userAccount = await _UserAccountService.GetUserAccountAsync(user.MemberId);

                if (userAccount != null)
                {
                    // TODO: User account already exists
                    SetErrorMessages(string.Format(AppString.AccountWithSameMemberIdExist, user.MemberId));
                }
                else
                {
                    try
                    {

                        await _UserAccountService.CreateUserAsync(user);
                        await _CheckInService.CreateLogInCredentialAsync(user);

                        return RedirectToAction(
                            actionName: nameof(UserToolController.Patrons),
                            controllerName: nameof(UserToolController).StripController());
                    }
                    catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                    when (ex.InnerException is System.Data.SqlClient.SqlException)
                    {
                        if (ex.InnerException.Message.Contains("Cannot insert duplicate key"))
                        {
                            // TODO: Revert DB actions on error
                        }
                        else
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        var errMessages = new List<string>();

                        while (ex != null)
                        {
                            errMessages.Add(ex.Message);
                            ex = ex.InnerException;
                        }

                        SetErrorMessages(errMessages);
                    }
                }
            }

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Patrons.cshtml");
        }

        public async Task<IActionResult> EditAccount(string memberId)
        {
            var account = await GetUserAccountAsync(memberId);

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/EditAccount.cshtml", account);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(UserAccountViewModel user)
        {
            if (MeetsBasicRequirements(user, false))
            {
                if (string.IsNullOrWhiteSpace(user.UpdatedMemberId) == false)
                {
                    user.MemberId = user.UpdatedMemberId.Trim();
                }

                await _UserAccountService.UpdateUserAccountAsync(user);
                return RedirectToAction(nameof(ViewAccount), new { MemberId = user.MemberId });
            }

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/EditAccount.cshtml", user);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveAccount(UserAccountViewModel user)
        {
            if (MeetsBasicRequirements(user))
            {
                await _UserAccountService.ApproveAccountAsync(user.MemberId);
            }

            return RedirectToAction(nameof(ViewAccount), new { MemberId = user?.MemberId });
        }

        [HttpPost]
        public async Task<IActionResult> SuspendAccount(UserAccountViewModel user)
        {
            if (MeetsBasicRequirements(user))
            {
                await _UserAccountService.SuspendUserAccountAsync(user.MemberId);
            }

            return RedirectToAction(nameof(ViewAccount), new { MemberId = user?.MemberId });
        }

        [HttpPost]
        public async Task<IActionResult> ReactivateAccount(UserAccountViewModel user)
        {
            if (MeetsBasicRequirements(user))
            {
                await _UserAccountService.ReactivateUserAccountAsync(user.MemberId);
            }

            return RedirectToAction(nameof(ViewAccount), new { MemberId = user?.MemberId });
        }

        [HttpPost]
        public IActionResult DeleteAccount(UserAccountViewModel user)
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Index.cshtml");
        }

        private async Task<UserAccountViewModel> GetUserAccountAsync(string memberId)
        {
            if (!string.IsNullOrWhiteSpace(memberId))
            {
                var account = await _UserAccountService.GetUserAccountAsync(memberId);

                if (Equals(account, null))
                {
                    SetErrorMessages(string.Format(AppString.AccountWithIdDoesntExist, memberId));
                }
                else
                {
                    account.RequestToken = HashString(account.MemberId);

                    if (AccountTypeToolsMapping.ContainsKey(account.AccountType))
                    {
                        SetActiveConsoleTool(AccountTypeToolsMapping[account.AccountType]);
                    }
                    else
                    {
                        SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS);
                    }
                }

                return account;
            }

            return null;
        }

        private bool MeetsBasicRequirements(UserAccountViewModel user, bool ignoreModelState = true)
        {
            if (!ignoreModelState && !ModelState.IsValid)
            {
                this.SetErrorMessages(ModelState.Values
                    .Where(val => val.ValidationState == ModelValidationState.Invalid)
                    .Select(val => val.Errors.FirstOrDefault().ErrorMessage));

                return false;
            }
            else if (Equals(user, null))
            {
                this.SetErrorMessages(AppString.GenericErrorMessage);

                return false;
            }
            else if (Equals(HashString(user.MemberId), user.RequestToken) == false)
            {
                this.SetErrorMessages(AppString.GenericErrorMessage);

                return false;
            }

            return true;
        }
    }
}