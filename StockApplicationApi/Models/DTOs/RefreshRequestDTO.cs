namespace StockApplicationApi.Models.DTOs
{
    public class RefreshRequestDTO
    {
        public string token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
