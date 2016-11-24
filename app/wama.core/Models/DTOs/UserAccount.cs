using System.ComponentModel.DataAnnotations;

namespace WAMA.Core.Models.DTOs
{
    public class UserAccount : TableRow
    {
        [Key]
        public string MemberId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserAccountType AccountType { get; set; }
        public bool IsSuspended { get; set; }
    }
}