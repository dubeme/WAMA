using Microsoft.AspNetCore.Mvc;

namespace WAMA.Web.Controllers
{
    public class AdminConsoleController : WamaBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}