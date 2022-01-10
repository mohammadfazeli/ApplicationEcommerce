using Api.Middelware;
using Microsoft.AspNetCore.Builder;

namespace Api.Helper.Extentions
{
    public static class CustomApplicationMiddelwareExtention
    {

        public static IApplicationBuilder UseCustomMiddelware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddelware>();


            return app;
        }
    }
}
