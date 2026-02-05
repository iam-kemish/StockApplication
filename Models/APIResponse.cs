using System.Net;

namespace StockApplication.Models
{
    public class APIResponse<T>
    {
        public int HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string? Errors { get; set; }

        public object Result { get; set; } = new object();

        public static APIResponse<T> Success(T data, int status = 200)
      => new() { IsSuccess = true, Result = data, HttpStatusCode = status };

        public static APIResponse<T> SuccessNoContent(int status = 204)
            => new() { IsSuccess = true, HttpStatusCode = status };

        public static APIResponse<T> Fail(string message, int status = 400)
            => new() { IsSuccess = false, Errors = message, HttpStatusCode = status };

        public static APIResponse<T> NotFound(string message = "Resource not found")
            => Fail(message, 404);

        public static APIResponse<T> ServerError(string? message = null)
            => Fail(message ?? "Internal server error", 500);
    }
}
