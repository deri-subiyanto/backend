namespace CoreBackend.Models
{
    public class RegisterDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string DataUser { get; set; } = "{}";
    }
}