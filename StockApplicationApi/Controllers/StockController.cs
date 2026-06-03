using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Services.StockServices;
using StockApplicationApi.Validators;
using System.Net;

namespace StockApplicationApi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IValidator<StockCreateDTO> _createValidator;
        private readonly IValidator<StockUpdateDTO> _updateValidator;

        public StockController(
            IStockService stockService,
            IValidator<StockCreateDTO> createValidator,
            IValidator<StockUpdateDTO> updateValidator)
        {
            _stockService = stockService;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ValidateFilter<StockCreateDTO>))]
        public async Task<IActionResult> Create([FromBody] StockCreateDTO dto)
        {
            
            bool isAdmin = User.IsInRole("Admin");
          
            var createdStock = await _stockService.AddStock(dto, isAdmin);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdStock.Id },   
                new APIResponse
                {
                    IsSuccess = true,
                    statusCode = HttpStatusCode.Created,
                    Message = "Stock created successfully",
                    Result = createdStock
                }
            );
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            
            var stock = await _stockService.GetStockById(id);
            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Result = stock
            });
        }

        [HttpPut("{id}")]
        [Authorize]
        [ServiceFilter(typeof(ValidateFilter<StockUpdateDTO>))]
        public async Task<IActionResult> Update(int id, [FromBody] StockUpdateDTO dto)
        {
           
            var updatedStock = await _stockService.UpdateStock(id, dto, isAdmin: User.IsInRole("Admin"));

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Message = "Stock updated successfully",
                Result = updatedStock
            });
        }

        [HttpGet]  
        public async Task<IActionResult> GetAll([FromQuery] StockQuery stockQuery)
        {
            var stocks = await _stockService.GetAllStocks(stockQuery);

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Result = stocks
            });
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            
            bool isAdmin = User.IsInRole("Admin");
            await _stockService.DeleteStock(id, isAdmin);

         return Ok(new APIResponse
         {
              IsSuccess = true,
              statusCode = HttpStatusCode.NoContent,
               Message = "Stock deleted successfully"
         }
               
            );
        }
    }
}