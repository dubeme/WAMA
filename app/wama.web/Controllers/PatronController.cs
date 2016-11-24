using Microsoft.AspNetCore.Mvc;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel.User;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WAMA.Web.Controllers
{
    public class PatronController : Controller
    {
        private IUserAccountService _UserAccountService;

        public PatronController(IUserAccountService userAccountService)
        {
            _UserAccountService = userAccountService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PatronUserAccountViewModel patron)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _UserAccountService.CreateUser(patron);

            return RedirectToAction(
                actionName: nameof(CheckInController.Index),
                controllerName: nameof(CheckInController).Replace(AppString.Controller, string.Empty));
        }
    }
}