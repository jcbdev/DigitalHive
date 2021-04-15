using DigitalHive.Api.Data.Models;
using DigitalHive.Api.Data.Models.DAO;
using System.Collections.Generic;
 
 namespace DigitalHive.Api.Data {
 public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);

        RegisterResponse Register(RegisterRequest model);
    }
 }