using FluentValidation;
using StockApplicationApi.Models.DTOs.StockDTOs;

namespace StockApplicationApi.Validators.Stocks
{
    public class StockCreateDtoValidator: AbstractValidator<StockCreateDTO>
    {
        public StockCreateDtoValidator()
        {
            RuleFor(x => x.symbol)
               .NotEmpty().WithMessage("Symbol is required")
               .MaximumLength(10).WithMessage("Symbol max 10 chars")
               .Matches("^[A-Z]+$").WithMessage("Symbol must be uppercase letters only");

            RuleFor(x => x.industry)
                .NotEmpty().WithMessage("Industry name is required")
                .MaximumLength(15).WithMessage("Use maximum 15 chars");
               

            RuleFor(x => x.companyName)
                .NotEmpty().WithMessage("Company name is required")
                .MaximumLength(100);

         

            RuleFor(x => x.marketCap)
                .GreaterThanOrEqualTo(1000).WithMessage("Market cap should be greater than or equal to 1000");
              
        }
    }
}
