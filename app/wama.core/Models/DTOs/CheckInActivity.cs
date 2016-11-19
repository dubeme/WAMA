using System;

namespace WAMA.Core.Models.DTOs
{
    public class CheckInActivity
    {
        public string MemberId { get; set; }
        public DateTimeOffset CheckInDateTime { get; set; }
    }
}