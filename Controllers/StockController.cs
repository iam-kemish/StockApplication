using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApplication.Repositary.StockRepositary;

namespace StockApplication.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStock _IStock;
        private readonly ILogger _ILogger;
        public StockController(IStock stock, ILogger iLogger)
        {
            _IStock = stock;
            _ILogger = iLogger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stocks = await _IStock.GetAllStocks();
            return Ok(stocks);

        }
    }
    
}
