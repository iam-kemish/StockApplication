using FluentValidation;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Validators.Stocks
{
    public class StockUpdateDtoValidator: AbstractValidator<StockUpdateDTO>
    {
        public StockUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
           .NotEmpty().WithMessage("ID is required for update")
           .GreaterThan(0).WithMessage("ID must be a positive number");

            RuleFor(x => x.Symbol)
               .NotEmpty().WithMessage("Symbol is required")
               .MaximumLength(10).WithMessage("Symbol max 10 chars")
               .Matches("^[A-Z]+$").WithMessage("Symbol must be uppercase letters only");
            RuleFor(x => x.Industry)
                .NotEmpty().WithMessage("Industry name is required")
                .MaximumLength(15).WithMessage("Use maximum 15 chars");
               

            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Company name is required")
                .MaximumLength(100);


            RuleFor(x => x.MarketCap)
                .GreaterThanOrEqualTo(1000).WithMessage("Market cap should be greater than or equal to 1000");
              
        }
    }
}
