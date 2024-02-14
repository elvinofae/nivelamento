using Blog.Appl.Interfaces;
using Blog.Appl.Interfaces.Services;
using Blog.Appl.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenConfiguration _token;
        private readonly IAuthService _auth;

        public AuthController(ITokenConfiguration token, IAuthService auth)
        {
            _token = token;   
            _auth = auth;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> LoginAsync([FromBody] UserRequest request)
        {
            var isCreated = await _auth.AddAsync(request);

            if (!isCreated) return BadRequest();

            return Ok();
        }

        [HttpGet("Login")]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var user = await _auth.GetByNameAsync(username);

            if (user is not null)
            {
                var token = _token.GenerateJwtToken(username, user.Role);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
