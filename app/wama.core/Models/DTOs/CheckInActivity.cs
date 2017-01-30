using System;

namespace WAMA.Core.Models.DTOs
{
    public class CheckInActivity : TableRow
    {
        public string MemberId { get; set; }

        public DateTimeOffset CheckInDateTime { get; set; }

        public bool IsCheckedIn { get; set; }

        public virtual UserAccount Member { get; set; }
    }
}