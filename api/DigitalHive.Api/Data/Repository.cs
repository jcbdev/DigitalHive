using System.Collections.Generic;
using DigitalHive.Api.Data.Models;

namespace DigitalHive.Api.Data {
  public class Respository : IRepository
  {
    public void CreateUser(User user)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<TimeSeriesReport> GetTimeSeries()
    {
      throw new System.NotImplementedException();
    }

    public void InsertTimeSeries(IEnumerable<TimeSeriesReport> timeSeries)
    {
      throw new System.NotImplementedException();
    }
  }
}