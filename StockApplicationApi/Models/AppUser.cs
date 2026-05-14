using Microsoft.AspNetCore.Identity;

namespace StockApplicationApi.Models
{
    public class AppUser:IdentityUser
    {
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
