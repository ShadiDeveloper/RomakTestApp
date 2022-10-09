using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Test2Controller : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicAction()
        {
            return Ok();
               
        }

        [HttpGet("private")]
        public IActionResult PrivateAction()
        {
            return Forbid();
        }
    }
}
