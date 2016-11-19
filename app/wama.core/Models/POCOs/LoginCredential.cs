namespace WAMA.Core.Models.POCOs
{
    public class LoginCredential
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public bool RequiresPassword { get; set; }
    }
}