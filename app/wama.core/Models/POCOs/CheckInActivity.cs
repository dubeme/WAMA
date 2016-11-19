using System;

namespace WAMA.Core.Models.POCOs
{
    public class CheckInActivity
    {
        public string MemberId { get; set; }
        public DateTimeOffset CheckInDateTime { get; set; }
    }
}