using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalHive.Api.Data.Models.DAO
{
    public class InsertTimeSeriesReportRequest
    {
        [Required]
        public IEnumerable<TimeSeriesReportRequest> rows { get; set; }
    }

    public class TimeSeriesReportRequest {
      
      [Required]
      public string date { get; set; }

      [Required]
      public string contract { get; set; }

      [Required]
      public float value { get; set; }

      [Required]
      public float rollingValue { get; set; }
    }
}
