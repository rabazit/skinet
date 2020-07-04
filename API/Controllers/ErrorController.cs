using API.Errors;
using Microsoft.AspNetCore.Mvc;

//create this controller for creating consistent response for unhandled error

namespace API.Controllers
{
    [Route("errors/{code}")]
    public class ErrorController : BaseApiController
    {

        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
