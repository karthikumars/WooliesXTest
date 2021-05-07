using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shopping.Models;
using System;
using System.Threading.Tasks;

namespace Shopping.Api.Infrastructure
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Unhandled error: {0}", exception.Message);

                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorResponse = new ErrorResponse();

            if (exception is HttpException httpException)
            {
                errorResponse.StatusCode = httpException.StatusCode;
                errorResponse.Message = httpException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)errorResponse.StatusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}