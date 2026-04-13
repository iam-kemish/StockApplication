using FluentValidation;
using StockApplicationApi.Models.DTOs;

namespace StockApplicationApi.Validators.Auth
{
    public class RegisterValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();

          
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters");
        }
    }
}
