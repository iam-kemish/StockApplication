using System.Text.Json.Serialization;

namespace StockApplicationApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public int StockId {  get; set; }
        [JsonIgnore]
        public Stock Stock { get; set; }
        public string? AppUserId { get; set; } 
        public AppUser AppUser { get; set; }
    }
}
