using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockApplicationApi.Features.Stocks.Commands;
using StockApplicationApi.Features.Stocks.Queries;
using StockApplicationApi.Helpers;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs.StockDTOs;
using StockApplicationApi.Validators;
using System.Net;

namespace StockApplicationApi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _IMediatr;
       
        private readonly IValidator<StockCreateDTO> _createValidator;
        private readonly IValidator<StockUpdateDTO> _updateValidator;

        public StockController(
           
            IValidator<StockCreateDTO> createValidator,
            IValidator<StockUpdateDTO> updateValidator,
            IMediator mediator)
        {
            _IMediatr = mediator;
         
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        [Authorize]
        [ServiceFilter(typeof(ValidateFilter<StockCreateDTO>))]
        public async Task<IActionResult> Create([FromBody] StockCreateDTO dto, CancellationToken  cancellationToken)
        {
            
            bool isAdmin = User.IsInRole("Admin");

            var query = new AddStockCommand(dto, isAdmin);
            var stock = await _IMediatr.Send(query, cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = stock.Id },   
                new APIResponse
                {
                    IsSuccess = true,
                    statusCode = HttpStatusCode.Created,
                    Message = "Stock created successfully",
                    Result = stock
                }
            );
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            
            var query = new GetStockById(id);
            var stock = await _IMediatr.Send(query, cancellationToken);
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
        public async Task<IActionResult> Update(int id, [FromBody] StockUpdateDTO dto, CancellationToken cancellationToken)
        {
            bool isAdmin = User.IsInRole("Admin");
            var query = new UpdateStockCommand(id, dto, isAdmin);
            var stock = await _IMediatr.Send(query, cancellationToken);
         

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Message = "Stock updated successfully",
                Result = stock
            });
        }

        [HttpGet]  
        public async Task<IActionResult> GetAll([FromQuery] StockQuery stockQuery, CancellationToken cancellationToken)
        {
            var query = new GetAllStocksQuery(stockQuery);
            var stocks = await _IMediatr.Send(query, cancellationToken);

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Result = stocks
            });
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var isAdmin = User.IsInRole("Admin");
            var query = new DeleteStockCommand(id, isAdmin);
            await _IMediatr.Send(query, cancellationToken);
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