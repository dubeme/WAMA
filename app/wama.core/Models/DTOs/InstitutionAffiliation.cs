using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.Models.DTOs
{
    public enum InstitutionAffiliation
    {
        [Display(Name = " --- ")]
        Unknown = 0,

        Student = 1,
        Faculty = 2,
        Staff = 3,
        Outsider = 4
    }
}