namespace WAMA.Core.Models.DTOs
{
    public class LogInCredential : TableRow
    {
        public string MemberId { get; set; }

        public string Password { get; set; }

        public bool RequiresPassword { get; set; }

        public virtual UserAccount Member { get; set; }
    }
}