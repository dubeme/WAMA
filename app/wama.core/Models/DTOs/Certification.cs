using System;

namespace WAMA.Core.Models.DTOs
{
    public class Certification : TableRow
    {
        public string MemberID { get; set; }
        public CertificationType Type { get; set; }
        public DateTimeOffset CertifiedOn { get; set; }
        public DateTimeOffset ExpiresOn { get; set; }
    }
}