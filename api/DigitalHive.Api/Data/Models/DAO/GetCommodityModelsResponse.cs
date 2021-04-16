using System.Collections.Generic;
using System.Linq;

namespace DigitalHive.Api.Data.Models.DAO
{

  public class GetCommodityModelsResponse {
    public IEnumerable<CommodityModelResponse> rows { get; set; }

    public GetCommodityModelsResponse(IEnumerable<CommodityModel> models) {
      rows = models.Select(m => new CommodityModelResponse(m));
    }
  }

  public class CommodityModelResponse
  {
      public int id { get; set; }
      public string date { get; set; }

      public string contract { get; set; }

      public float price { get; set; }

      public int position { get; set; }

      public int newTradeAction { get; set; }

      public float pnlDaily { get; set; }

      public string model { get; set; }

      public string commodity { get; set; }

      public float pnlYtd { get; set; }

      public float pnlLtd { get; set; }

      public float mddYtd { get; set; }


    public CommodityModelResponse(CommodityModel model)
    {
      id = model.ID;
      date = model.Date.ToUniversalTime().ToString("o");
      contract = model.Contract;
      price = model.Price;
      position = model.Position;
      newTradeAction = model.NewTradeAction;
      pnlDaily = model.PnlDaily;
      this.model = model.Model;
      commodity = model.Commodity;
      pnlYtd = model.PnlYtd;
      pnlLtd = model.PnlLtd;
      mddYtd = model.MddYtd;
    }
  }
}