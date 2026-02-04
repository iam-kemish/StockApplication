using System.Net;

namespace StockApplication.Models
{
    public class APIResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public object Result { get; set; }
    }
}
