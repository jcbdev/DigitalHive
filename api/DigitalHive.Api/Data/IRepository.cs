using System.Collections.Generic;
using DigitalHive.Api.Data.Models;

namespace DigitalHive.Api.Data {
  public interface IRepository {
    public User RegisterUser(User user);
    public IEnumerable<User> ListUsers();
    public User GetUser(string username);
    public User GetUserById(int id);
    public void InsertTimeSeries(IEnumerable<TimeSeriesReport> timeSeries);
    public IEnumerable<TimeSeriesReport> GetTimeSeries();
  }
}