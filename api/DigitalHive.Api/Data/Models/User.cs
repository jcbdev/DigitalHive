using System;

namespace DigitalHive.Api.Data.Models {
  public class User {
    public int ID { get; set; }
    public string Password { get; set;  }
    public string Role { get; set; }
  }
}