using MediatR;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Features.Stocks.Commands
{
    public record AddStockCommand(StockCreateDTO stock, bool isAdmin = true) : IRequest<StockDTO>
    {
    }
}
