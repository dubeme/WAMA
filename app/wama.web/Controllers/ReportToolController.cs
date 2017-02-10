using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models.Service;
using WAMA.Core.ViewModel;
using WAMA.Web.Model;

namespace WAMA.Web.Controllers
{
    public class ReportToolController : WamaBaseController
    {
        private ICheckInService _CheckInService;
        private IUserAccountService _UserAccountService;
        private ICSVService _CSVService;

        public ReportToolController(ICheckInService checkInService, IUserAccountService userAccountService, ICSVService csvService)
        {
            _CheckInService = checkInService;
            _UserAccountService = userAccountService;
            _CSVService = csvService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(CheckIns));
        }

        [HttpPost]
        public async Task<IActionResult> DownloadCSV(ReportToolFilterViewModel filter)
        {
            byte[] csvBytes = null;
            var extension = "";
            var fileName = "";

            switch (filter.ActiveTool)
            {
                case Constants.ADMIN_CONSOLE_REPORTS_CHECK_INS:
                    var checkIns = await _CheckInService.GetCheckInActivitiesForPeriodAsync(filter.StartDate, filter.EndDate);
                    extension = "text/csv";
                    fileName = "check-ins.csv";

                    if (Equals(checkIns, null) == false)
                    {
                        csvBytes = System.Text.Encoding.ASCII.GetBytes(_CSVService.ToCSV(checkIns));
                    }

                    break;

                case Constants.ADMIN_CONSOLE_REPORTS_LISTSERV:
                    var listservData = await _UserAccountService.GetListservDataAsync(Core.Models.DTOs.UserAccountType.Patron);
                    extension = "text/txt";
                    fileName = "patron-emails.txt";

                    if (Equals(listservData, null) == false)
                    {
                        var formattedEmails = listservData
                            .Select(ls => $"{ls.LastName}, {ls.FirstName} {ls.MiddleName} <{ls.Email}>");

                        csvBytes = System.Text.Encoding.ASCII.GetBytes(string.Join(";", formattedEmails));
                    }

                    break;

                default:
                    break;
            }

            SetActiveConsoleTool(filter.ActiveTool);

            return File(csvBytes, extension, fileName);
        }

        public IActionResult CheckIns()
        {
            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_REPORTS_CHECK_INS);
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/CheckIns.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CheckIns(ReportToolFilterViewModel filter)
        {
            var checkIns = await _CheckInService.GetCheckInActivitiesForPeriodAsync(filter.StartDate, filter.EndDate);
            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_REPORTS_CHECK_INS);

            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/CheckIns.cshtml", checkIns);
        }

        public IActionResult Users()
        {
            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_REPORTS_USERS);
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Users.cshtml");
        }

        public async Task<IActionResult> Listserv()
        {
            var listservData = await _UserAccountService.GetListservDataAsync(Core.Models.DTOs.UserAccountType.Patron);
            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_REPORTS_LISTSERV);

            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Listserv.cshtml", listservData);
        }

        public IActionResult Clinics()
        {
            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_REPORTS_CLINICS);
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Clinics.cshtml");
        }
    }
}