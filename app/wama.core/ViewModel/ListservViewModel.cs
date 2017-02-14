using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WAMA.Core.Models.Contracts;
using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    public class ListservViewModel : ISerializableToCSV
    {
        public virtual UserAccountType AccountType { get; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public IEnumerable<string> Headers
        {
            get
            {
                return new string[] {
                    nameof(FirstName),
                    nameof(LastName),
                    nameof(MiddleName),
                    nameof(Email)
                };
            }
        }

        public IEnumerable<string> CSVString
        {
            get
            {
                return new string[] {
                    FirstName,
                    LastName,
                    MiddleName,
                    Email
                };
            }
        }
    }
}