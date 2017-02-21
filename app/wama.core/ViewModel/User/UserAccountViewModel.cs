using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public abstract class UserAccountViewModel
    {
        public virtual UserAccountType AccountType { get; }
        [Required]
        [Display(Name = "ID (7 digit SDSU ID)")]
        public string MemberId { get; set; }

        [Display(Name = "Updated ID (7 digit SDSU ID)")]
        public string UpdatedMemberId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Affiliation with the school")]
        public InstitutionAffiliation InstitutionAffiliation { get; set; }

        [Display(Name = "Account has been approved")]
        public bool HasBeenApproved { get; set; }

        [Display(Name = "Account is suspended")]
        public bool IsSuspended { get; set; }

        public string RequestToken { get; set; }
    }
}