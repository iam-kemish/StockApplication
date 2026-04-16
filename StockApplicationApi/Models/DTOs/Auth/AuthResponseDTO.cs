namespace StockApplicationApi.Models.DTOs.Auth
{
    public class AuthResponseDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; }
    }
}
