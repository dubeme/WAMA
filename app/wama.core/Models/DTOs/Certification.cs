using System;

namespace WAMA.Core.Models.DTOs
{
    public class Certification : TableRow
    {
        public string MemberId { get; set; }
        public CertificationType Type { get; set; }
        public DateTimeOffset CertifiedOn { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }

        public virtual UserAccount Member { get; set; }
    }
}