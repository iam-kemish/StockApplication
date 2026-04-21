using FluentValidation;
using StockApplicationApi.Models.DTOs;

namespace StockApplicationApi.Validators.Auth
{
    public class RegisterValidator:AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().MinimumLength(5);
            RuleFor(x => x.Email)
     .NotEmpty()
     .EmailAddress() 
     .Must(email => email.ToLower().EndsWith("@gmail.com"))
     .WithMessage("Only Valid Gmail addresses are allowed.");

            RuleFor(x => x.Password)
    .NotEmpty().WithMessage("Password is required")
    .MinimumLength(8)
    .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
    .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
    .Matches(@"[0-9]").WithMessage("Password must contain at least one digit")
    .Matches(@"[\!\?\*\.\@]").WithMessage("Password must contain at least one special character (! or ? or * or . or @)");
        }
    }
}
