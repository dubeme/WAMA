using Microsoft.AspNetCore.Mvc;
using WAMA.Core.Models.Service;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WAMA.Web.Controllers
{
    public class CheckInController : WamaBaseController
    {
        private static ICheckInService _CheckInService;

        public CheckInController(ICheckInService checkInService)
        {
            _CheckInService = checkInService;
        }

        [HttpGet]
        public IActionResult Index()
        {
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
                    SetErrorMessages("The ID that you entered does not exit.Please Try again or contact the manager ");
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