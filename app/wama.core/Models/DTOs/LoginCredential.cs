namespace WAMA.Core.Models.DTOs
{
    public class LogInCredential : TableRow
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool RequiresPassword { get; set; }
    }
}