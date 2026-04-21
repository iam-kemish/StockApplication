using System;
using System.Collections.Generic;
using System.Net;

namespace StockApplicationApi.Exceptions
{
    // Base exception
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public AppException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }

    // 404 Not Found
    public sealed class NotFoundException : AppException
    {
        public NotFoundException(string message)
            : base(message, HttpStatusCode.NotFound)
        {
        }
    }
    // 400 Bad Request
    public sealed class BadRequestException : AppException
    {
        public BadRequestException(string message)
            : base(message, HttpStatusCode.BadRequest)
        {
        }
    }

    // 409 Conflict (e.g., duplicate)
    public sealed class ConflictException : AppException
    {
        public ConflictException(string message)
            : base(message, HttpStatusCode.Conflict)
        {
        }
    }
    public sealed class UnAuthorizedException : AppException
    {
        public UnAuthorizedException(string message)
            :base(message, HttpStatusCode.Unauthorized)
        {        
        }
    }
    public class OperationFailedException : AppException
    {
        public IEnumerable<string> Errors { get; }

        public OperationFailedException(string message, IEnumerable<string> errors)
            : base(message)
        {
            Errors = errors;
        }
    }
    // Validation errors
    public sealed class AppValidationException : AppException
    {
        public IDictionary<string, string[]> Errors { get; }

        public AppValidationException(IDictionary<string, string[]> errors)
            : base("One or more validation errors occurred.", HttpStatusCode.BadRequest)
        {
            Errors = errors;
        }

        public AppValidationException(string field, string error)
            : base("One or more validation errors occurred.", HttpStatusCode.BadRequest)
        {
            Errors = new Dictionary<string, string[]>
            {
                { field, new[] { error } }
            };
        }
    }
}