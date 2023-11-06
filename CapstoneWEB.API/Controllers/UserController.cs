using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CapstoneWEB.CORE.DTOs;
using CapstoneWEB.CORE.Interfaces;
using CapstoneWEB.CORE.Services;

namespace CapstoneWEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserLoginDTO userLoginDTO)
        {
            var result = await _userService.SignIn(userLoginDTO);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UserRegisterDTO userRegisterDTO)
        {
            var result = await _userService.SignUp(userRegisterDTO);
            if (!result)
                return BadRequest();
            return Ok(result);

        }
    }
}
