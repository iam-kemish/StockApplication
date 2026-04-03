using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplicationApi.Models.DTOs.StockDTOs
{
    public class StockDTO
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

       
        public decimal Purchase { get; set; }

       
        public decimal LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
