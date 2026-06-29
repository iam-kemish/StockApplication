using MediatR;
using StockApplicationApi.Models.DTOs.CommentDTOs;

namespace StockApplicationApi.Features.Comments.Queries
{
    public record GetAllCommentsQuery() : IRequest<IEnumerable<CommentDto>>
    {
    }
}
