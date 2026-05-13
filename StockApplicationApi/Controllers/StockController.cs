using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Services.StockServices;
using System.Net;
using System.Security.Claims;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] StockCreateDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var validationResult = await _createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                throw new AppValidationException(errors);
            }

            var createdStock = await _stockService.AddStock(dto, userId!);

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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var stock = await _stockService.GetStockById(id, userId!);
            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Result = stock
            });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] StockUpdateDTO dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                throw new AppValidationException(errors);
            }

            var updatedStock = await _stockService.UpdateStock(id, dto, userId!);

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _stockService.DeleteStock(id, userId!);

            return NoContent(); 
        }
    }
}