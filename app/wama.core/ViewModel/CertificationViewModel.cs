using System;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    public class CertificationViewModel
    {
        public string MemberId { get; set; }
        public CertificationType Type { get; set; }
        public DateTimeOffset CertifiedOn { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }

        public virtual UserAccount Member { get; set; }
    }
}