using FluentValidation;
using StockApplicationApi.Models.DTOs.CommentDTOs;

namespace StockApplicationApi.Validators.Comments
{
    public class CommentCreateDtoValidator: AbstractValidator<CreateComment>
    {
        public CommentCreateDtoValidator() {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Content)
                .NotEmpty()
                .MinimumLength(10)     
                .MaximumLength(1000);
        }
    }
}
