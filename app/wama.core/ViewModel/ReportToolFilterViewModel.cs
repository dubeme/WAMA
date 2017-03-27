using System;
using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents ReportToolFilterViewModel
    /// </summary>
    public class ReportToolFilterViewModel
    {
        /// <summary>
        /// Gets or sets the report granularity of this ReportToolFilterViewModel.
        /// </summary>
        [Required]
        [Display(Name = "Report Granularity")]
        public ReportGranularity ReportGranularity { get; set; }

        /// <summary>
        /// Gets or sets the start date of this ReportToolFilterViewModel.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.MinValue;

        /// <summary>
        /// Gets or sets the end date of this ReportToolFilterViewModel.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTimeOffset EndDate { get; set; } = DateTimeOffset.MaxValue;

        /// <summary>
        /// Gets or sets the active tool of this ReportToolFilterViewModel.
        /// </summary>
        public string ActiveTool { get; set; }

        public UserSearchFilterViewModel UserSearchFilter { get; set; }
    }
}