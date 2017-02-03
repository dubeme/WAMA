using System;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    public class CheckInActivityViewModel
    {
        public string MemberId { get; set; }

        public DateTimeOffset CheckInDateTime { get; set; }

        public bool IsCheckedIn { get; set; }

        public virtual UserAccount Member { get; set; }
    }
}