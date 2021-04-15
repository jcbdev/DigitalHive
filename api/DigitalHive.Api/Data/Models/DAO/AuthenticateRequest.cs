using System.ComponentModel.DataAnnotations;

namespace DigitalHive.Api.Data.Models.DAO
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
