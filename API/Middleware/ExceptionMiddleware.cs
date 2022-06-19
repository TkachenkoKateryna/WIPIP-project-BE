using System.Net;
using Domain.Models.Logger;
using Domain.Interfaces.Util;
using Domain.Models.Exceptions;
using Domain.Models.Entities.Base;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var error = new ErrorDetails();

            switch (exception) 
            {
                case NotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    error.Message = exception.Message;
                    break;
                case AlreadyExistsException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    error.Field = (string)exception.Data["field"];
                    error.Message = exception.Message;
                    break;
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    error.Message = exception.Message;
                    break;
                case Exception:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    error.Message = "Sorry, something went wrong";
                    break;
            }

            context.Response.ContentType = "application/json";

            error.StatusCode = context.Response.StatusCode;

            await context.Response.WriteAsync(error.ToString());
        }
    }
}
