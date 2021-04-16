#nullable enable
using System.Collections.Generic;
using DigitalHive.Api.Data.Models;

namespace DigitalHive.Api.Data {
  public interface IRepository {
    public User RegisterUser(User user);
    public IEnumerable<User> ListUsers();
    public User? GetUser(string username);
    public User? GetUserById(int id);
    public void ClearUsers(string username);
    public void InsertTimeSeries(IEnumerable<TimeSeriesReport> timeSeries);
    public void InsertCommodityModels(IEnumerable<CommodityModel> models);
    public void ClearAll();
    public IEnumerable<TimeSeriesReport> GetTimeSeries();
    public IEnumerable<CommodityModel> GetCommodityModels(string? model, string? commodity);
  }
}