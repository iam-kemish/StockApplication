using MediatR;

namespace StockApplicationApi.Features.Stocks.Commands
{
    public record DeleteStockCommand(int id, bool isAdmin = true) : IRequest
    {
    }
}
