using AuthProject.Services.Dtos;
using AuthProject.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test1Controller : ControllerBase
    {
        private readonly IUserService _userService;

        public Test1Controller(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var token = await _userService.LoginAsync(model);
            return Ok(token);
        }
           
    }
}
