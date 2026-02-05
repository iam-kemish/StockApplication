using System.Net;

namespace StockApplication.Models
{
    public class APIResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();

        public object Result { get; set; } = new object();
    }
}
