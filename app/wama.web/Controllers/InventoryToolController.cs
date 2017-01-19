using Microsoft.AspNetCore.Mvc;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public class InventoryToolController : Controller
    {
        public IActionResult Index()
        {
            return View($"{Constants.ADMIN_CONSOLE_INVENTORY_TOOL_DIRECTORY}/Index.cshtml");
        }
    }
}