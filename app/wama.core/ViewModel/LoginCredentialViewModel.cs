using WAMA.Core.Models.DTOs;

namespace WAMA.Core.ViewModel
{
    public class LogInCredentialViewModel
    {
        public string MemberId { get; set; }

        public string Password { get; set; }

        public bool RequiresPassword { get; set; }

        public virtual UserAccount Member { get; set; }
    }
}