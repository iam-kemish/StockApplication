using MediatR;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Features.Stocks.Commands
{
    public record UpdateStockCommand(int id, StockUpdateDTO stock, bool isAdmin = true) : IRequest<StockDTO>
    {
        
    }
}
