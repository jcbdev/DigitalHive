using System.Collections.Generic;
using DigitalHive.Api.Data.Models;

namespace DigitalHive.Api.Data {
  public interface IRepository {
    public void CreateUser(User user);
    public void InsertTimeSeries(IEnumerable<TimeSeriesReport> timeSeries);
    public IEnumerable<TimeSeriesReport> GetTimeSeries();
  }
}