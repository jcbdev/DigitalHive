namespace DigitalHive.Api.Data.Models.DAO
{
  public class RegisterResponse
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }


    public RegisterResponse(User user)
    {
      Id = user.ID;
      Username = user.Username;
      Role = Role;
    }
  }
}