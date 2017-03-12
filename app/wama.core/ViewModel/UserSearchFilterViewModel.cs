using System;
using System.Collections.Generic;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    /// <summary>
    /// Represents UserSearchFilterViewModel. <para />
    /// This class is used to specify filters used to search for <see cref="UserAccount"/>>
    /// </summary>
    public class UserSearchFilterViewModel
    {
        /// <summary>
        /// Gets or sets the name of this UserSearchFilterViewModel.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the member i ds of this UserSearchFilterViewModel.
        /// </summary>
        public IEnumerable<string> MemberIDs { get; set; }

        /// <summary>
        /// Gets or sets the account types of this UserSearchFilterViewModel.
        /// </summary>
        public IEnumerable<UserAccountType> AccountTypes { get; set; }

        /// <summary>
        /// Gets or sets the account is suspended of this UserSearchFilterViewModel.
        /// </summary>
        public bool? AccountIsSuspended { get; set; }

        /// <summary>
        /// Gets or sets the account is approved of this UserSearchFilterViewModel.
        /// </summary>
        public bool? AccountIsApproved { get; set; }

        /// <summary>
        /// Gets or sets the certified on of this UserSearchFilterViewModel.
        /// </summary>
        public DateTime? CertifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the certified after of this UserSearchFilterViewModel.
        /// </summary>
        public DateTime? CertifiedAfter { get; set; }

        /// <summary>
        /// Gets or sets the certified before of this UserSearchFilterViewModel.
        /// </summary>
        public DateTime? CertifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the signed waiver on of this UserSearchFilterViewModel.
        /// </summary>
        public DateTime? SignedWaiverOn { get; set; }

        /// <summary>
        /// Gets or sets the signed waiver after of this UserSearchFilterViewModel.
        /// </summary>
        public DateTime? SignedWaiverAfter { get; set; }

        /// <summary>
        /// Gets or sets the signed waiver before of this UserSearchFilterViewModel.
        /// </summary>
        public DateTime? SignedWaiverBefore { get; set; }
    }
}