using MediatR;
using StockApplicationApi.Helpers;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Features.Stocks.Queries
{
    public record GetAllStocksQuery(StockQuery StockQuery): IRequest<IEnumerable<StockDTO>>
    {
    }
}
