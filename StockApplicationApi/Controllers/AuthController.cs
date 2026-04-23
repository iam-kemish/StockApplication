using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Services.AuthService;
using System.Net;

namespace StockApplicationApi.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IValidator<RegisterDTO> _validator;

        public AuthController(IAuthService authService, IValidator<RegisterDTO> validator)
        {
            _authService = authService;
            _validator = validator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(
                    new APIResponse
                    {
                        Errors = errors,
                        IsSuccess = false,
                        statusCode = HttpStatusCode.BadRequest,
                        Result = null,
                        Message = "something went wrong."
                    }

                    );
            }
            var result = await _authService.Register(dto);
            return Ok(
                   new APIResponse
                   {
                       Errors = null,
                       IsSuccess = true,
                       statusCode = HttpStatusCode.OK,
                       Result = result,
                       Message = "User registered successfully."
                   }
               );
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
           
            var result = await _authService.Login(dto);
            return Ok(
                    new APIResponse
                    {
                        Errors = null,
                        IsSuccess = true,
                        statusCode = HttpStatusCode.OK,
                        Result = result,
                        Message = "User logged in successfully."
                    }
                );
        }
    }
}
