using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using StockApplicationApi.Exceptions;

namespace StockApplicationApi.Validators
{
    public class ValidateFilter<T> : IAsyncActionFilter where T : class
    {
        private readonly IValidator<T> _validator;

        public ValidateFilter(IValidator<T> validator)
        {
            _validator = validator;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var dto = context.ActionArguments.Values.OfType<T>().FirstOrDefault();
            if (dto != null)
            {
                var result = await _validator.ValidateAsync(dto);
                if (!result.IsValid)
                {
                    var errors = result.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToArray()
                        );
                    throw new AppValidationException(errors);
                }
                
            }
                await next();
        }
    }
}