using Azure;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApplication.Models;
using StockApplication.Repositary.StockRepositary;

namespace StockApplication.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStock _IStock;
        private readonly ILogger<StockController> _ILogger;
        private readonly APIResponse response;
        public StockController(IStock stock, ILogger<StockController> iLogger)
        {
            _IStock = stock;
            _ILogger = iLogger;
            response = new();

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetStocks()
        {
            try
            {
                _ILogger.LogInformation("Getting all the stocks");
                response.Result = await _IStock.GetAllStocks();
                response.HttpStatusCode = System.Net.HttpStatusCode.OK;

            }
            catch (Exception ex) {
                _ILogger.LogInformation("below exceptions was found");
                response.HttpStatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Errors = new List<string> { ex.Message };
            }
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetStock(int id)
        {
            if (id == 0)
            {
                response.HttpStatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.Errors = new List<string> { "Invalid hotel ID" };
                return BadRequest(response);
            }
            var stock = await _IStock.GetStock(u => u.Id == id);
            if(stock == null)
            {
                response.HttpStatusCode = HttpStatusCode.NotFound;
                response.IsSuccess = false;
                response.Errors = new List<string> { "Stock not found" };
                return BadRequest(response);
            }
            response.Result = stock;
            response.HttpStatusCode = HttpStatusCode.OK;
            response.IsSuccess = true;
            return Ok(response);
        }
    }
    
}
