using System.Collections.Generic;
using System.Linq;

namespace DigitalHive.Api.Data.Models.DAO
{

  public class GetTimeSeriesReportReponse {
    public IEnumerable<TimeSeriesReportResponse> rows { get; set; }

    public GetTimeSeriesReportReponse(IEnumerable<TimeSeriesReport> models) {
      rows = models.Select(m => new TimeSeriesReportResponse(m));
    }
  }

  public class TimeSeriesReportResponse
  {
    public int id { get; set; }
    public string date { get; set; }

    public string contract { get; set; }

    public float value { get; set; }


    public float rollingValue { get; set; }


    public TimeSeriesReportResponse(TimeSeriesReport model)
    {
      id = model.ID;
      date = model.Date.ToUniversalTime().ToString("o");
      contract = model.Contract;
      value = model.Value;
      rollingValue = model.RollingValue;
    }
  }
}