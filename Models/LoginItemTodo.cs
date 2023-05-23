using System.ComponentModel.DataAnnotations;

namespace OfficeAPI.Models
{
    public class LoginItemTodo
    {
        [Key]
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsLoggedIn { get; set; }
    }
    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
