using Microsoft.AspNetCore.Mvc;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public class ClinicToolController : WamaBaseController
    {
        public IActionResult Index()
        {
            return View($"{Constants.ADMIN_CONSOLE_CLINIC_TOOL_DIRECTORY}/Index.cshtml");
        }
    }
}