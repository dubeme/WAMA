using Microsoft.AspNetCore.Mvc;
using WAMA.Core.Models.Service;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WAMA.Web.Controllers
{
    public class CheckInController : Controller
    {
        private static ICheckInService _CheckInService;

        public CheckInController(ICheckInService checkInService)
        {
            _CheckInService = checkInService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var ttt = new WAMA.Core.Models.DTOs.Certification();
            return View();
        }

        [HttpPost]
        public IActionResult Index(string id)
        {
            if (ModelState.IsValid)
            {
                var loginCredential = _CheckInService.GetLogInCredential(id);

                if (loginCredential == null)
                {
                    return RedirectToAction(nameof(PatronController.Create), nameof(PatronController).Replace(AppString.Controller, string.Empty));
                }
                else
                {
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult WaiverNotSigned()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WaiverSignedButCertificationExpired()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Successful()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccountSuspended()
        {
            return View();
        }
    }
}