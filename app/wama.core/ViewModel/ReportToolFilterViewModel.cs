using System;
using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.ViewModel
{
    public class ReportToolFilterViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.MinValue;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTimeOffset EndDate { get; set; } = DateTimeOffset.MaxValue;

        public string ActiveTool { get; set; }
    }
}