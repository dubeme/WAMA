using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WAMA.Core.Models.Service;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WAMA.Web.Controllers
{
    public class CheckInController : WamaBaseController
    {
        private static ICheckInService _CheckInService;
        private static IUserAccountService _UserAccountService;

        public CheckInController(ICheckInService checkInService, IUserAccountService userAccountService)
        {
            _CheckInService = checkInService;
            _UserAccountService = userAccountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string memberId)
        {
            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(memberId))
            {
                var loginCredential = await _CheckInService.GetLogInCredentialAsync(memberId);
                var ApprovedStatus = await _UserAccountService.GetUserAccountAsync(memberId);
                if (loginCredential == null)
                {
                    ViewBag.AccountExists = "false";
                    SetErrorMessages("The ID that you entered does not exit. Please check your ID or Press create new account for new account");
                }
                else
                {
                    if (ApprovedStatus.HasBeenApproved == false) //if not approved
                    {
                        SetErrorMessages("The following member is awaiting on approval, please contact front desk");
                    }
                    else
                    {
                        return RedirectToAction(
                            actionName: nameof(Successful),
                            routeValues: memberId);
                    }
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