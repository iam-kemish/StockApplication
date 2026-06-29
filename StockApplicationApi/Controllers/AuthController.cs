using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Services.AuthService;
using StockApplicationApi.Validators;
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
        [ServiceFilter(typeof(ValidateFilter<RegisterDTO>))]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
          
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
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestDTO dto)
        {
            var result = await _authService.RefreshToken(dto.token, dto.RefreshToken);

            return Ok(new APIResponse
            {
                IsSuccess = true,
                statusCode = HttpStatusCode.OK,
                Message = "Token refreshed successfully",
                Result = result
            });
        }
    }
}
