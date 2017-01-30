using System;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    public class WaiverViewModel
    {
        public string MemberId { get; set; }

        public DateTimeOffset SignedOn { get; set; }

        public virtual UserAccount Member { get; set; }
    }
}