using Microsoft.AspNetCore.Mvc;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public class ReportToolController : Controller
    {
        public IActionResult Index()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Index.cshtml");
        }

        public IActionResult CheckIns()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/CheckIns.cshtml");
        }

        public IActionResult Users()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Users.cshtml");
        }

        public IActionResult Listserv()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Listserv.cshtml");
        }

        public IActionResult Clinics()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Clinics.cshtml");
        }
    }
}