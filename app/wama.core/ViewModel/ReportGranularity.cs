using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.ViewModel
{
    public enum ReportGranularity
    {
        [Display(Name = "Individual  actions")]
        Individual,

        [Display(Name = "Hourly Aggregate")]
        Hourly,

        [Display(Name = "Daily Aggregate")]
        Daily,

        [Display(Name = "Weekly Aggregate")]
        Weekly,

        [Display(Name = "Monthly Aggregate")]
        Monthly,

        [Display(Name = "Yearly Aggregate")]
        Yearly
    }
}