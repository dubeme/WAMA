using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents how granular the report are aggregated.
    /// </summary>
    public enum ReportGranularity
    {
        /// <summary>
        /// Individual actions
        /// </summary>
        [Display(Name = "Individual  actions")]
        Individual,

        /// <summary>
        /// Hourly
        /// </summary>
        [Display(Name = "Hourly Aggregate")]
        Hourly,

        /// <summary>
        /// Daily
        /// </summary>
        [Display(Name = "Daily Aggregate")]
        Daily,

        /// <summary>
        /// Weekly
        /// </summary>
        [Display(Name = "Weekly Aggregate")]
        Weekly,

        /// <summary>
        /// Monthly
        /// </summary>
        [Display(Name = "Monthly Aggregate")]
        Monthly,

        /// <summary>
        /// Yearly
        /// </summary>
        [Display(Name = "Yearly Aggregate")]
        Yearly
    }
}