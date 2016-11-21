using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel.User
{
    public abstract class UserAccountViewModel
    {
        public UserAccountType AccountType { get; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Member Id")]
        public string MemberId { get; set; }
    }
}