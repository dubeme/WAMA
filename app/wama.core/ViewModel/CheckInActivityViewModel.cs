using System;
using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.Attributes;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    public class CheckInActivityViewModel
    {
        [Display(Name = "Member ID")]
        public string MemberId { get; set; }

        [Display(Name = "Check In Date/Time")]
        [CSVIgnore]
        public DateTimeOffset CheckInDateTime { get; set; }

        [Display(Name = "Is checked in")]
        public bool IsCheckedIn { get; set; }

        [Display(Name = "Check in Date")]
        public string Date => $"{CheckInDateTime:D}";

        [Display(Name = "Check in Time")]
        public string Time => $"{CheckInDateTime:T}";

        [Display(Name = "Member")]
        [CSVIgnore]
        public virtual UserAccount Member { get; set; }
    }
}