using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.Models.Service;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public class UserToolController : WamaBaseController
    {
        private IUserAccountService _UserAccountService;

        public UserToolController(IUserAccountService userAccountService)
        {
            _UserAccountService = userAccountService;
        }

        public IActionResult Index()
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Index.cshtml");
        }

        public async Task<IActionResult> Administrators()
        {
            var accounts =await  _UserAccountService.GetUserAccountsAsync(UserAccountType.Administrator);
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Administrators.cshtml", accounts);
        }

        public async Task<IActionResult> Employees()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(UserAccountType.Employee);
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Employees.cshtml", accounts);
        }

        public async Task<IActionResult> Managers()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(UserAccountType.Manager);
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Managers.cshtml", accounts);
        }

        public async Task<IActionResult> Patrons()
        {
            var accounts = await _UserAccountService.GetUserAccountsAsync(UserAccountType.Patron);
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Patrons.cshtml", accounts);
        }
    }
}