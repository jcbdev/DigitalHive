using System.Collections.Generic;
using System.Linq;
using DigitalHive.Api.Data.Models;

namespace DigitalHive.Api.Data {
  public class Respository : IRepository
  {
    private readonly DigitalHiveContext _db;

    public Respository(DigitalHiveContext db) {
      _db = db;
    }

    public IEnumerable<TimeSeriesReport> GetTimeSeries()
    {
      throw new System.NotImplementedException();
    }

    public User GetUser(string username)
    {
      return _db.Set<User>().SingleOrDefault(u => u.Username == username);
    }

    public User GetUserById(int id)
    {
      return _db.Set<User>().SingleOrDefault(u => u.ID == id);
    }

    public IEnumerable<User> ListUsers()
    {
      return _db.Set<User>();
    }

    public void ClearUsers(string username) {
      _db.Users.RemoveRange(_db.Users.Where(u => u.Username == username));
      _db.SaveChanges();
    }

    public void InsertTimeSeries(IEnumerable<TimeSeriesReport> timeSeries)
    {
      throw new System.NotImplementedException();
    }

    public User RegisterUser(User newUser)
    {
      var user = _db.Add<User>(newUser);
      _db.SaveChanges();
      return user.Entity;
    }
  }
}