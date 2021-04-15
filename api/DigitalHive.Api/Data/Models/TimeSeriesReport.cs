using System;

namespace DigitalHive.Api.Data.Models
{
  public class TimeSeriesReport {
    public int ID { get; set; }

    public DateTime Date { get; set; }
    public string Contract { get; set; }
    public float Value { get; set; }
    public float RollingValue { get; set; }
  }
}