using System.Collections.Generic;

namespace WAMA.Core.ViewModel
{
    public class CheckInReportResultViewModel
    {
        public ReportToolFilterViewModel ReportFilter { get; set; }
        public IEnumerable<CheckInActivityViewModel> IndividualCheckInActivities { get; set; }
        public IEnumerable<CheckInActivityAggregateViewModel> CheckInActivityAggregates { get; set; }
    }
}