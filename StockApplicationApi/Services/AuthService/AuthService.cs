using StockApplicationApi.Models.DTOs;

namespace StockApplicationApi.Services.AuthService
{
    public class AuthService : IAuthService
    {
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
