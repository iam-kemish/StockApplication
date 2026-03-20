using System.Net;

namespace StockApplication.Models
{
    public class APIResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Errors { get; set; }
        public object Result { get; set; } = new object();

    
    }
}
