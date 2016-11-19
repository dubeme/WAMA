using Models.POCOs;

namespace WAMA.Core.Models.POCOs
{
    public class UserAccount
    {
        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserAccountType AccountType { get; set; }
    }
}