using System.Net;
using Domain.Models.Logger;
using Domain.Interfaces.Util;
using Domain.Models.Exceptions;
using Domain.Models.Entities.Base;
using System;

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
            var error = new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            if (exception is NotFoundException<BaseEntity>)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            if (exception is UnauthorizedAccessException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            if (exception is Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }
}
