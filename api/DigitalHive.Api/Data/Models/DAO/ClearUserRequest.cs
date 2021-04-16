using System.ComponentModel.DataAnnotations;

namespace DigitalHive.Api.Data.Models.DAO
{
    public class ClearUserRequest
    {
        [Required]
        public string username { get; set; }
    }
}
