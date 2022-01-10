using Api.Errors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Middelware
{
    public class ExceptionMiddelware
    {
        private readonly ILogger<ExceptionMiddelware> _logger;
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _envirement;

        public ExceptionMiddelware(ILogger<ExceptionMiddelware> logger, RequestDelegate next,
            IHostEnvironment envirement)
        {
            _logger = logger;
            _next = next;
            _envirement = envirement;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = _envirement.IsDevelopment() ?
                    new ErrorException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                    :
                    new ErrorException((int)HttpStatusCode.InternalServerError, ex.Message);

                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, option);

                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}