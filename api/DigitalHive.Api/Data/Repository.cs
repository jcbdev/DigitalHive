#nullable enable
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
      return _db.Set<TimeSeriesReport>().OrderBy(ts => ts.Date);
    }

    public User? GetUser(string username)
    {
      return _db.Set<User>().SingleOrDefault(u => u.Username == username);
    }

    public User? GetUserById(int id)
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

    public void ClearAll() {
      _db.Users.RemoveRange(_db.Users.ToList());
      _db.TimeSeriesReports.RemoveRange(_db.TimeSeriesReports.ToList());
      _db.CommodityModels.RemoveRange(_db.CommodityModels.ToList());
      _db.SaveChanges();
    }

    public void InsertTimeSeries(IEnumerable<TimeSeriesReport> timeSeries)
    {
      _db.Set<TimeSeriesReport>().AddRange(timeSeries);
      _db.SaveChanges();
    }

    public User RegisterUser(User newUser)
    {
      var user = _db.Add<User>(newUser);
      _db.SaveChanges();
      return user.Entity;
    }

    public void InsertCommodityModels(IEnumerable<CommodityModel> models)
    {
      _db.Set<CommodityModel>().AddRange(models);
      _db.SaveChanges();
    }

    public IEnumerable<CommodityModel> GetCommodityModels(string? model = null, string? commodity = null)
    {
      var query = _db.Set<CommodityModel>().Select(q => q);
      if (model != null) {
        query = query.Where(m => m.Model == model);
      }
      if (commodity != null) {
        query = query.Where(m => m.Commodity == commodity);
      }
      return query.OrderBy(m => m.Commodity).ThenBy(m => m.Model).ThenBy(m => m.Date);
    }
  }
}