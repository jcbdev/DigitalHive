using System;

namespace DigitalHive.Api.Data.Models
{
  public class CommodityModel {
    public int ID { get; set; }

    public DateTime Date { get; set; }
    public string Contract { get; set; }
    public float Price { get; set; }
    public int Position { get; set; }
    public int NewTradeAction { get; set; }
    public float PnlDaily { get; set; }
    public string Model { get; set; }
    public string Commodity { get; set; }
    public float PnlYtd { get; set; }
    public float PnlLtd { get; set; }
    public float MddYtd { get; set; }
  }
}