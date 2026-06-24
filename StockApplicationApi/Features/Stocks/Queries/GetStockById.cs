using MediatR;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Features.Stocks.Queries
{
    public record GetStockById(int id) : IRequest<StockDTO>;
   
}
