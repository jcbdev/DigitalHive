using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalHive.Api.Data;
using DigitalHive.Api.Data.Models;
using DigitalHive.Api.Data.Models.DAO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DigitalHive.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class DataController : ControllerBase
    {
        private readonly ILogger<DataController> _logger;
        private readonly IRepository _repository;

        public DataController(ILogger<DataController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [Route("timeseries")]
        public IActionResult InsertTimeSeries(InsertTimeSeriesReportRequest model)
        {
            var timeSeries = model.rows.Select(r => new TimeSeriesReport() {
                Contract = r.contract,
                Date = DateTime.Parse(r.date, null, System.Globalization.DateTimeStyles.RoundtripKind),
                RollingValue = r.rollingValue,
                Value = r.value
            });
            _repository.InsertTimeSeries(timeSeries);
            return Ok();
        }

        [HttpGet]
        [Route("timeseries")]
        public IActionResult GetTimeSeries()
        {
            var timeSeries = _repository.GetTimeSeries();
            var response = new GetTimeSeriesReportReponse(timeSeries);
            return Ok(response);
        }

        [HttpPost]
        [Route("models")]
        public IActionResult InsertCommodityModels(InsertCommodityModelsRequest model)
        {
            var models = model.rows.Select(r => new CommodityModel() {
                Contract = r.contract,
                Date = DateTime.Parse(r.date, null, System.Globalization.DateTimeStyles.RoundtripKind),
                Commodity = r.commodity,
                Model = r.model,
                MddYtd = r.mddYtd,
                NewTradeAction = r.newTradeAction,
                PnlDaily = r.pnlDaily,
                PnlLtd = r.pnlLtd,
                PnlYtd = r.pnlYtd,
                Position = r.position,
                Price = r.price
            });
            _repository.InsertCommodityModels(models);
            return Ok();
        }

        [HttpGet]
        [Route("models/{model?}/{commodity?}")]
        public IActionResult GetCommodityModels([FromQuery] string model, [FromQuery] string commodity)
        {
            Console.WriteLine($"Model: {model}");
            Console.WriteLine($"Commodity: {commodity}");
            var commodityModels = _repository.GetCommodityModels(model, commodity);
            var response = new GetCommodityModelsResponse(commodityModels);
            return Ok(response);
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult ClearAll()
        {
            _repository.ClearAll();
            return Ok();
        }
    }
}
