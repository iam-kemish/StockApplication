using Microsoft.AspNetCore.Identity;
using StockApplicationApi.Models;
using StockApplicationApi.Models.DTOs;

namespace StockApplicationApi.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signinManager;
        public AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signinManager = signInManager;
        }
        public Task<AuthResponseDTO> Login(LoginDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponseDTO> Register(RegisterDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
