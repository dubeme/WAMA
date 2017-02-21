using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WAMA.Web.Controllers
{
    public class CheckInController : WamaBaseController
    {
        private IUserAccountService _UserAccountService;
        private IWaiverService _waiverService;
        private static ICheckInService _CheckInService;

        public CheckInController(IUserAccountService userAccountService, ICheckInService checkInService, IWaiverService waiverService)
        {
            _UserAccountService = userAccountService;
            _waiverService = waiverService;
            _CheckInService = checkInService;
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
                var userAccount = await _UserAccountService.GetUserAccountAsync(memberId);
                var waiverInfo = await _waiverService.GetWaiverAsync(memberId);

                if (userAccount == null)
                {
                    ViewBag.AccountExists = "false";
                    ViewBag.MemberId = memberId;
                    SetErrorMessages(string.Format(AppString.NoAccountExistsWithID, memberId));
                }
                else if (!userAccount.HasBeenApproved)
                {
                    SetErrorMessages(AppString.AccountPendingApprovalMessage);
                }
                else if (waiverInfo == null || System.DateTimeOffset.Now.Subtract(waiverInfo.SignedOn).TotalDays >= 90)
                {
                    return RedirectToAction(
                        actionName: nameof(Waiver),
                        routeValues: new
                        {
                            MemberId = memberId
                        });
                }
                else
                {
                    await _CheckInService.PerformCheckInAsync(memberId);
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

        [HttpPost]
        public async Task<IActionResult> Waiver(string signerName, string memberId)
        {
            var userAccount = await _UserAccountService.GetUserAccountAsync(memberId);

            string userName = userAccount.FirstName + " " + userAccount.LastName;

            if (signerName == null || !signerName.Equals(userName))
            {
                SetErrorMessages(AppString.SignatureMismatch);
            }
            else
            {
                WaiverViewModel waiverViewMode = new WaiverViewModel();
                waiverViewMode.MemberId = memberId;
                waiverViewMode.SignedOn = System.DateTimeOffset.Now;
                await _waiverService.AddWaiverAsync(waiverViewMode);
                return RedirectToAction(actionName: nameof(Successful));
            }

            ViewBag.MemberId = memberId;
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
        public IActionResult Waiver(string memberId)
        {
            ViewBag.MemberId = memberId;
            return View();
        }

        [HttpGet]
        public IActionResult AccountSuspended()
        {
            return View();
        }
    }
}