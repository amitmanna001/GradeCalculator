using System.ComponentModel.DataAnnotations;

namespace RegistrationLoginDemo.Models
{
    public class Login
    {
        [Key]
        public int loginid { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
    }
}
