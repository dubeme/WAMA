using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WAMA.Core.Models.Service;
using WAMA.Core.Services;
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
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Index.cshtml");
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

        [HttpPost]
        public async Task<IActionResult> DownloadCSV(ReportToolFilterViewModel filter)
        {
            var checkIns = await _CheckInService.GetCheckInActivitiesForPeriodAsync(filter.StartDate, filter.EndDate);
            SetActiveConsoleTool(filter.ActiveTool);
            var csvBytes = System.Text.Encoding.ASCII.GetBytes(_CSVService.ToCSV(checkIns));

            return File(csvBytes, "text/csv", "check-ins.csv");
        }

        public IActionResult Users()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Users.cshtml");
        }

        public IActionResult Listserv()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Listserv.cshtml");
        }

        public IActionResult Clinics()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/Clinics.cshtml");
        }
    }
}