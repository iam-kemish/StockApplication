using StockApplicationApi.Models.DTOs;

namespace StockApplicationApi.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> Register(RegisterDTO dto);
        Task<AuthResponseDTO> Login(LoginDTO dto);
    }
}
