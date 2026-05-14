using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using System.Net;
using System.Text.Json;

public class GlobalException
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _env;

    public GlobalException(RequestDelegate next, IWebHostEnvironment webHostEnvironment)
    {
        _next = next;
        _env = webHostEnvironment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new APIResponse
        {
            IsSuccess = false,
            statusCode = HttpStatusCode.InternalServerError,
            Message = "An unexpected error occurred.",
            Errors = null
        };

        switch (exception)
        {
            case AppValidationException ex:
                response.statusCode = HttpStatusCode.BadRequest;
                response.Message = "Validation failed.";
                response.Errors = ex.Errors;
                break;

            case NotFoundException ex:
                response.statusCode = HttpStatusCode.NotFound;
                response.Message = "Resource not found.";
                response.Errors = new { detail = ex.Message };
                break;

            case BadRequestException ex:
                response.statusCode = HttpStatusCode.BadRequest;
                response.Message = "Invalid request.";
                response.Errors = new { detail = ex.Message };
                break;

            case ConflictException ex:
                response.statusCode = HttpStatusCode.Conflict;
                response.Message = "Conflict occurred.";
                response.Errors = new { detail = ex.Message };
                break;
            case UnAuthorizedException ex:
                response.statusCode = HttpStatusCode.Unauthorized;
                response.Message = "Unauthorized access.";
                response.Errors = new { detail = ex.Message };
                break;

            case AppException ex:
                response.statusCode = ex.StatusCode;
                response.Message = "Application error occurred.";
                response.Errors = new { detail = ex.Message };
                break;

            default:
                response.statusCode = HttpStatusCode.InternalServerError;
                response.Message = "Internal server error. Please try again later.";

                if (_env.IsDevelopment())
                {
                    response.Errors = new
                    {
                        detail = exception.Message,
                        stackTrace = exception.StackTrace
                    };
                }
                else
                {
                    response.Errors = new { detail = response.Message };
                }
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.statusCode;

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
    }
}