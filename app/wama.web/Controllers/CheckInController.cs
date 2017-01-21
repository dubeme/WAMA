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
        public IActionResult Index(string memberId)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(memberId))
            {
                var loginCredential = _CheckInService.GetLogInCredential(memberId);

                if (loginCredential == null)
                {
                    return RedirectToAction(
                        actionName: nameof(PatronController.Create),
                        controllerName: nameof(PatronController).Replace(AppString.Controller, string.Empty),
                        routeValues: new { ReceavedId = memberId });
                }
                else
                {
                    return RedirectToAction(
                        actionName: nameof(Successful),
                        routeValues: memberId);
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