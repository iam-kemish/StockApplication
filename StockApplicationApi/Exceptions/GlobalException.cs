using StockApplicationApi.Exceptions;
using StockApplicationApi.Models;
using System.Net;
using System.Text.Json;

public class GlobalException
{
    private readonly RequestDelegate _next;

    public GlobalException(RequestDelegate next)
    {
        _next = next;
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
            case AppValidationException validationEx:
                response.statusCode = HttpStatusCode.BadRequest;
                response.Message = validationEx.Message;
                response.Errors = validationEx.Errors;
                break;

            case NotFoundException notFoundEx:
                response.statusCode = HttpStatusCode.NotFound;
                response.Message = notFoundEx.Message;
                break;

            case BadRequestException badRequestEx:
                response.statusCode = HttpStatusCode.BadRequest;
                response.Message = badRequestEx.Message;
                break;

            case ConflictException conflictEx:
                response.statusCode = HttpStatusCode.Conflict;
                response.Message = conflictEx.Message;
                break;

            case AppException appEx:
                // fallback for any other AppException we might add later
                response.statusCode  = appEx.StatusCode;
                response.Message = appEx.Message;
                break;

            default:
                // This will show us the EXACT reason MapOpenApi is crashing
                response.Message = exception.Message;
                response.Errors = new { stackTrace = exception.StackTrace };
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.statusCode;

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
    }
}