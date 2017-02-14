using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.Contracts;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    public class CheckInActivityViewModel : ISerializableToCSV
    {
        [Display(Name = "Member ID")]
        public string MemberId { get; set; }

        [Display(Name = "Check In Date/Time")]
        public DateTimeOffset CheckInDateTime { get; set; }

        [Display(Name = "Is checked in")]
        public bool IsCheckedIn { get; set; }

        [Display(Name = "Check in Date")]
        public string Date => $"{CheckInDateTime:D}";

        [Display(Name = "Check in Time")]
        public string Time => $"{CheckInDateTime:T}";

        [Display(Name = "Member")]
        public virtual UserAccount Member { get; set; }

        public IEnumerable<string> Headers
        {
            get
            {
                return new string[] {
                    nameof(MemberId),
                    nameof(IsCheckedIn),
                    nameof(Date),
                    nameof(Time)
                };
            }
        }

        public IEnumerable<string> CSVString
        {
            get
            {
                return new string[] {
                    MemberId,
                    IsCheckedIn.ToString(),
                    Date,
                    Time
                };
            }
        }
    }
}