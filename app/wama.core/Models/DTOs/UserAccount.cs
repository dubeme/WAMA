using WAMA.Core.Models.DTOs;

namespace WAMA.Core.Models.DTOs
{
    public class UserAccount : TableRow
    {
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserAccountType AccountType { get; set; }
    }
}