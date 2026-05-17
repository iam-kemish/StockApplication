using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplicationApi.Models.RefreshTokens
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime Expires { get; set; }
       
        public DateTime Created { get; set; }
        public bool IsUsed { get; set; } = false;   
        public bool IsRevoked { get; set; } = false;

        public string AppUserId { get; set; } = string.Empty;

        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; } = null!;
    }
}