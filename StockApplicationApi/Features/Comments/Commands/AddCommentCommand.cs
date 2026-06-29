using MediatR;
using StockApplicationApi.Models.DTOs.CommentDTOs;

namespace StockApplicationApi.Features.Comments.Commands
{
    public record AddCommentCommand(CreateComment Comment, int StockId, string UserId, bool IsCustomer) : IRequest<CommentDto>
    {
    }
}
