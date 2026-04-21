using Microsoft.AspNetCore.Identity;
using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;
using StockApplicationApi.Services.Token;

namespace StockApplicationApi.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthService(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDTO> Register(RegisterDTO dto)
        {
          
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                throw new ConflictException("Email already exists.");
            }

            var user = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new OperationFailedException("Operation failed",errors);
            }

            // create Customer role if doesnt exist
            if (!await _roleManager.RoleExistsAsync("Customer"))
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

            // assign default role
            await _userManager.AddToRoleAsync(user, "Customer");

            return new AuthResponseDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = null
            };
        }

        public async Task<AuthResponseDTO> Login(LoginDTO dto)
        {
            // find user by email
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                throw new NotFoundException("Invalid credentials this username might be wrong or empty");

        
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isPasswordValid)
            {
                throw new UnAuthorizedException("Invalid credentials");
            }
            var token = _tokenService.CreateAccessToken(user);

            return new AuthResponseDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            };
        }
    }
}