using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.Models.DTOs
{
    public enum Gender
    {
        [Display(Name = " --- ")]
        Unknown = 0,

        Male = 1,
        Female = 2,
        Other = 3,

        [Display(Name = "Prefer not to say")]
        PrefferNotToSay = 4
    }
}