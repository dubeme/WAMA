using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAMA.Core.Models.Contracts;
using WAMA.Core.Models.DTOs;
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
            return RedirectToAction(nameof(CheckInReports));
        }

        [HttpPost]
        public async Task<IActionResult> DownloadCSV(ReportToolFilterViewModel filter)
        {
            byte[] csvBytes = null;
            var extension = "";
            var fileName = "";
            var reportDate = $"{filter.StartDate:yyyyMMdd}_{filter.EndDate:yyyyMMdd}";

            switch (filter.ActiveTool)
            {
                case Constants.ADMIN_CONSOLE_REPORTS_CHECK_INS:

                    IEnumerable<ISerializableToCSV> reports;

                    if (filter.ReportGranularity == ReportGranularity.Individual)
                    {
                        reports = await _CheckInService
                            .GetCheckInActivitiesForPeriodAsync(filter.StartDate, filter.EndDate);
                    }
                    else
                    {
                        reports = await _CheckInService
                            .GetCheckInActivityAggregatesAsync(filter.StartDate, filter.EndDate, filter.ReportGranularity);
                    }

                    extension = "text/csv";
                    fileName = $"check-in_{reportDate}.csv";

                    if (Equals(reports, null) == false)
                    {
                        csvBytes = System.Text.Encoding.ASCII.GetBytes(_CSVService.ToCSV(reports));
                    }

                    break;

                case Constants.ADMIN_CONSOLE_REPORTS_USERS:
                    var listservData = await _UserAccountService.GetUserAccountsAsync(filter.UserSearchFilter);
                    extension = "text/txt";
                    fileName = $"listserv_{reportDate}.txt";

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

        public IActionResult CheckInReports()
        {
            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_REPORTS_CHECK_INS);

            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/CheckInReports.cshtml", new ReportToolFilterViewModel
            {
                StartDate = new DateTimeOffset(2017, 1, 1, 0, 0, 0, TimeSpan.FromHours(0)),
                EndDate = DateTimeOffset.Now,
                ActiveTool = Constants.ADMIN_CONSOLE_REPORTS_CHECK_INS
            });
        }

        [HttpPost]
        public IActionResult CheckInReports(ReportToolFilterViewModel filter)
        {
            var queryParams = new Dictionary<string, object>
            {
                { nameof(filter.StartDate), $"{filter.StartDate:MM-dd-yyyy}" },
                { nameof(filter.EndDate), $"{filter.EndDate:MM-dd-yyyy}"},
                { nameof(filter.ReportGranularity), filter.ReportGranularity },
                { nameof(filter.ActiveTool), filter.ActiveTool },
            };

            return RedirectToAction(nameof(CheckIns), queryParams);
        }

        public async Task<IActionResult> CheckIns(ReportToolFilterViewModel filter)
        {
            if (string.IsNullOrWhiteSpace(filter.ActiveTool))
            {
                return RedirectToAction(nameof(CheckInReports));
            }

            filter.EndDate = filter.EndDate.AddDays(1);

            var result = new CheckInReportResultViewModel
            {
                ReportFilter = filter
            };

            if (filter.ReportGranularity == ReportGranularity.Individual)
            {
                result.IndividualCheckInActivities = await _CheckInService
                    .GetCheckInActivitiesForPeriodAsync(filter.StartDate, filter.EndDate);
            }
            else
            {
                result.CheckInActivityAggregates = await _CheckInService
                    .GetCheckInActivityAggregatesAsync(filter.StartDate, filter.EndDate, filter.ReportGranularity);
            }

            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_REPORTS_CHECK_INS);

            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/CheckIns.cshtml", result);
        }

        [HttpGet]
        public IActionResult Users()
        {
            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/AdvancedSearch.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Users(UserSearchFilterViewModel filter)
        {
            SetActiveConsoleTool(Constants.ADMIN_CONSOLE_REPORTS_USERS);
            var users = await _UserAccountService.GetUserAccountsAsync(filter);

            ViewData["filter"] = new ReportToolFilterViewModel
            {
                ActiveTool = Constants.ADMIN_CONSOLE_REPORTS_USERS,
                UserSearchFilter = filter
            };

            return View($"{Constants.ADMIN_CONSOLE_REPORT_TOOL_DIRECTORY}/FilteredResult.cshtml", users);
        }
    }
}