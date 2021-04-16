using System.ComponentModel.DataAnnotations;

namespace DigitalHive.Api.Data.Models.DAO
{
    public class RegisterRequest
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string role { get; set; }
    }
}
