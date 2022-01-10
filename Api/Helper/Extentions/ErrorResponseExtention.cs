using Api.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Api.Helper.Extentions
{
    public static class ErrorResponseExtention
    {
        public static IServiceCollection ConfigErrorRespone(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = actionError =>
                {
                    string[] errors = actionError.ModelState
                    .Where(e => e.Value.Errors.Any())
                     .SelectMany(s => s.Value.Errors)
                     .Select(s => s.ErrorMessage).ToArray();

                    ApiValidationErrorResponse errorResponse = new()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
            return services;
        }
    }
}