using Api.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    public class TestErrorController : BaseController
    {
        public TestErrorController()
        {
        }

        [HttpGet("NotFound")]
        public ActionResult itemNotFound()
        {
            return NotFound(new ApiResponse((int)HttpStatusCode.NotFound));
        }

        [HttpGet("CheckUnauthorized")]
        public ActionResult itemUnauthorized()
        {
            return Unauthorized(new ApiResponse((int)HttpStatusCode.Unauthorized));
        }

        [HttpGet("CheckBadRequest")]
        public ActionResult itemBadRequest()
        {
            return BadRequest(new ApiResponse((int)HttpStatusCode.BadRequest));
        }
    }
}