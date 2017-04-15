using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WAMA.Core.Models.Service;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public class AdminConsoleController : WamaBaseController
    {
        private IUserAccountService _UserAccountService;

        public AdminConsoleController(IUserAccountService userAccountService)
        {
            _UserAccountService = userAccountService;
        }

        public async Task<IActionResult> Index()
        {
            var aggregate = await _UserAccountService.GetOverallActivityAggregatesAsync();

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_HOME);
            return View(aggregate);
        }
    }
}