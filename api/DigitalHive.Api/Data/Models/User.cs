using System.Text.Json.Serialization;

namespace DigitalHive.Api.Data.Models
{
  public class User {
    public int ID { get; set; }

    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set;  }
    public string Role { get; set; }
  }
}