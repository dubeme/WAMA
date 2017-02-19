using System;

namespace WAMA.Core.Models.DTOs
{
    public class Waiver : TableRow
    {
        public string MemberId { get; set; }

        public DateTimeOffset SignedOn { get; set; }

        public virtual UserAccount Member { get; set; }
    }
}