using System.ComponentModel.DataAnnotations;

namespace DigitalHive.Api.Data.Models.DAO
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.ID;
            Username = user.Username;
            Token = token;
        }
    }
}