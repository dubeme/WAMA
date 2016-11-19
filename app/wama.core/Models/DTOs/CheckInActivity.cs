using System;

namespace WAMA.Core.Models.DTOs
{
    public class CheckInActivity : TableRow
    {
        public string MemberId { get; set; }
        public DateTimeOffset CheckInDateTime { get; set; }
    }
}