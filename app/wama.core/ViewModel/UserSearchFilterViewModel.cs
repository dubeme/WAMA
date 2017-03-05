using System;
using System.Collections.Generic;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    public class UserSearchFilterViewModel
    {
        public string Name { get; set; }

        public IEnumerable<string> MemberIDs { get; set; }

        public IEnumerable<UserAccountType> AccountTypes { get; set; }

        public bool? AccountIsSuspended { get; set; }

        public bool? AccountIsApproved { get; set; }

        public DateTime? CertifiedOn { get; set; }

        public DateTime? CertifiedAfter { get; set; }

        public DateTime? CertifiedBefore { get; set; }

        public DateTime? SignedWaiverOn { get; set; }

        public DateTime? SignedWaiverAfter { get; set; }

        public DateTime? SignedWaiverBefore { get; set; }
    }
}