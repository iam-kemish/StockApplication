using System.Net;
using System.Text.Json.Serialization;

namespace StockApplication.Models
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; } = true;


        [JsonPropertyName("statusCode")]
        public HttpStatusCode statusCode { get; set; }
        public object Result { get; set; }
        public string? Message { get; set; }   
        public object? Errors { get; set; }


    }
}
