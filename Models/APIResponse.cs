using System.Net;

namespace StockApplication.Models
{
    public class APIResponse
    {
        public int HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Errors { get; set; }
        public object Result { get; set; } = new object();

    
    }
}
