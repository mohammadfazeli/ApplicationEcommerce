using Api.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("error/{statusCode}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseController
    {
        public ErrorController()
        {
        }


        public ActionResult Error(int statusCode)
        {
            return new ObjectResult(new ApiResponse(statusCode));
        }

    }
}