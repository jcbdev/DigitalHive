using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DigitalHive.Api.Data.Models.DAO
{
    public class InsertCommodityModelsRequest
    {
        [Required]
        public IEnumerable<CommodityModelRequest> rows { get; set; }
    }

    public class CommodityModelRequest {
      
      [Required]
      public string date { get; set; }

      [Required]
      public string contract { get; set; }

      [Required]
      public float price { get; set; }

      [Required]
      public int position { get; set; }
      [Required]
      public int newTradeAction { get; set; }
      [Required]
      public float pnlDaily { get; set; }
      [Required]
      public string model { get; set; }
      [Required]
      public string commodity { get; set; }
      [Required]
      public float pnlYtd { get; set; }
      [Required]
      public float pnlLtd { get; set; }
      [Required]
      public float mddYtd { get; set; }
    }
}
