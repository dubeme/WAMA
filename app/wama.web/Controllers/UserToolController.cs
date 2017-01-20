using Microsoft.AspNetCore.Mvc;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public class UserToolController : WamaBaseController
    {
        public IActionResult Index()
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Index.cshtml");
        }

        public IActionResult Administrators()
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Administrators.cshtml");
        }

        public IActionResult Employees()
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Employees.cshtml");
        }

        public IActionResult Managers()
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Managers.cshtml");
        }

        public IActionResult Patrons()
        {
            return View($"{Constants.ADMIN_CONSOLE_USER_TOOL_DIRECTORY}/Patrons.cshtml");
        }
    }
}