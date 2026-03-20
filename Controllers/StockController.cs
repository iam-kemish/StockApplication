using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StockApplication.Models;
using StockApplication.Models.DTOs;
using StockApplication.Services.StockServices;
using System.Net;

namespace StockApplication.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _IStockService;
        private readonly IValidator<StockCreateDTO> _StockCreate;
        public StockController(IStockService stockService, IValidator<StockCreateDTO> StockCreate)
        {
            _IStockService = stockService;
            _StockCreate = StockCreate;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StockCreateDTO dto)
        {
            var ValidationResult = await _StockCreate.ValidateAsync(dto);

            if (!ValidationResult.IsValid)
            {
                // Nice structured response (compatible with ProblemDetails)
                var firstError = ValidationResult.Errors.FirstOrDefault()?.ErrorMessage
                          ?? "Validation failed";
                return BadRequest(new APIResponse
                {
                    IsSuccess = false,
                    statusCode = HttpStatusCode.BadRequest,
                    Errors = firstError,   
                    Result = dto
                });
            }

            var stock = await _IStockService.AddStock(dto);
            return Created(string.Empty,new APIResponse
            {
                Result = stock,
                statusCode = System.Net.HttpStatusCode.Created
            });
        }
    }
    
}
