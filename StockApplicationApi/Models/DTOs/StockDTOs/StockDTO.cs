using System.ComponentModel.DataAnnotations.Schema;

namespace StockApplicationApi.Models.DTOs.StockDTOs
{
    public class StockDTO
    {
        public int id { get; set; }
        public string symbol { get; set; } = string.Empty;
        public string companyName { get; set; } = string.Empty;
 
        public decimal purchase { get; set; }

       
        public decimal lastDiv { get; set; }

        public string industry { get; set; } = string.Empty;  
        public long marketCap { get; set; }
                                            
        public IEnumerable<Comment> comments { get; set; } = new List<Comment>();
    }
}
