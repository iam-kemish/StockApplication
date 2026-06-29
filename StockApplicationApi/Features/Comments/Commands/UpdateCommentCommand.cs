using MediatR;
using StockApplicationApi.Models.DTOs.CommentDTOs;

namespace StockApplicationApi.Features.Comments.Commands
{
    public record UpdateCommentCommand(int id, CommentUpdateDTO comment, string userId, bool isCustomer = true) : IRequest<CommentDto>
    {
        
    }
}
