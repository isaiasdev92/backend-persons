using System;
using System.Net;
using ExameSoftware.Dtos;
using Newtonsoft.Json;

namespace ExameSoftware.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
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
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var apiResponse = new ApiResponse<dynamic>();

            apiResponse.Errors = new List<string> { "Internal Server Error from the custom middleware." };
            var jsonErrorResponse = JsonConvert.SerializeObject(apiResponse);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(jsonErrorResponse);
        }
    }
}

