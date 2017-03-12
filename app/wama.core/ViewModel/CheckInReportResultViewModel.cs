using System.Collections.Generic;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents CheckInReportResultViewModel
    /// </summary>
    public class CheckInReportResultViewModel
    {
        /// <summary>
        /// Gets or sets the report filter of this CheckInReportResultViewModel.
        /// </summary>
        public ReportToolFilterViewModel ReportFilter { get; set; }
        /// <summary>
        /// Gets or sets the individual check in activities of this CheckInReportResultViewModel.
        /// </summary>
        public IEnumerable<CheckInActivityViewModel> IndividualCheckInActivities { get; set; }
        /// <summary>
        /// Gets or sets the check in activity aggregates of this CheckInReportResultViewModel.
        /// </summary>
        public IEnumerable<CheckInActivityAggregateViewModel> CheckInActivityAggregates { get; set; }
    }
}