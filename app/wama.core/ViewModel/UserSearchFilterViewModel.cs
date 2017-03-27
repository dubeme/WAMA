using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        [Display(Name = "Name:")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the member i ds of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "MemberIDs")]
        public IEnumerable<string> MemberIDs
        {
            get
            {
                if (string.IsNullOrWhiteSpace(CommaSeparatedMemberIDs))
                {
                    return Enumerable.Empty<string>();
                }

                return CommaSeparatedMemberIDs.Split(',').Select(id => id.Trim());
            }
        }

        /// <summary>
        /// Gets or sets the member i ds of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Comma Separated MemberIDs")]
        public string CommaSeparatedMemberIDs { get; set; }

        /// <summary>
        /// Gets or sets the account types of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Account Type:")]
        public IEnumerable<UserAccountType> AccountTypes { get; set; }

        /// <summary>
        /// Gets or sets the account is suspended of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Suspension Status:")]
        public bool AccountIsSuspended { get; set; }

        /// <summary>
        /// Gets or sets the account is approved of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Approval Status:")]
        public bool AccountIsApproved { get; set; }

        /// <summary>
        /// Gets or sets the certified on of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Certification Certified On:")]
        [DataType(DataType.Date)]
        public DateTime? CertifiedOn { get; set; }

        /// <summary>
        /// Gets or sets the certified after of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Certification Certified After:")]
        [DataType(DataType.Date)]
        public DateTime? CertifiedAfter { get; set; }

        /// <summary>
        /// Gets or sets the certified before of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Certification Certified Before:")]
        [DataType(DataType.Date)]
        public DateTime? CertifiedBefore { get; set; }

        /// <summary>
        /// Gets or sets the signed waiver on of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Waiver Signed Date On:")]
        [DataType(DataType.Date)]
        public DateTime? SignedWaiverOn { get; set; }

        /// <summary>
        /// Gets or sets the signed waiver after of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Waiver Signed Date After:")]
        [DataType(DataType.Date)]
        public DateTime? SignedWaiverAfter { get; set; }

        /// <summary>
        /// Gets or sets the signed waiver before of this UserSearchFilterViewModel.
        /// </summary>
        [Display(Name = "Waiver Signed Date Before:")]
        [DataType(DataType.Date)]
        public DateTime? SignedWaiverBefore { get; set; }
    }
}