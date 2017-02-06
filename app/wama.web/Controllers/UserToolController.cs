using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Service;
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

        public UserToolController(IUserAccountService userAccountService)
        {
            _UserAccountService = userAccountService;
        }

        public IActionResult Index()
        {
            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS);
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Index.cshtml");
        }

        public async Task<IActionResult> Administrators()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(UserAccountType.Administrator);

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS_ADMINISTRATORS);
            ViewData[Constants.USER_ACCOUNT_TYPE] = AppString.AdministratorLabel;

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Administrators.cshtml", accounts);
        }

        public async Task<IActionResult> Employees()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(UserAccountType.Employee);

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS_EMPLOYEES);
            ViewData[Constants.USER_ACCOUNT_TYPE] = AppString.EmployeeLabel;

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Employees.cshtml", accounts);
        }

        public async Task<IActionResult> Managers()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(UserAccountType.Manager);

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS_MANAGERS);
            ViewData[Constants.USER_ACCOUNT_TYPE] = AppString.ManagerLabel;

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Managers.cshtml", accounts);
        }

        public async Task<IActionResult> Patrons()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(UserAccountType.Patron);

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

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/ViewAccount.cshtml", account);
        }

        public async Task<IActionResult> EditAccount(string memberId)
        {
            UserAccountViewModel account = null;

            if (!string.IsNullOrWhiteSpace(memberId))
            {
                account = await _UserAccountService.GetUserAccountAsync(memberId);

                if (Equals(account, null))
                {
                    SetErrorMessages(string.Format(AppString.AccountWithIdDoesntExist, memberId));
                }
                else if (AccountTypeToolsMapping.ContainsKey(account.AccountType))
                {
                    SetActiveConsoleTool(AccountTypeToolsMapping[account.AccountType]);
                }
                else
                {
                    SetActiveConsoleTool(Constants.ADMIN_CONSOLE_USERS);
                }
            }

            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/EditAccount.cshtml", account);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(UserAccountViewModel user)
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(UserAccountType.Patron);
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/EditAccount.cshtml", accounts);
        }

        [HttpPost]
        public IActionResult DeleteAccount(UserAccountViewModel user)
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Index.cshtml");
        }
    }
}