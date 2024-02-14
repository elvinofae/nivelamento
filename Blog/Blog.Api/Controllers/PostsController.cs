using Blog.Appl.Interfaces.Services;
using Blog.Appl.Request;
using Blog.Appl.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("Posts")]
        public async Task<ActionResult<IEnumerable<PostResponse>>> GetAsync()
        {
            return await _postService.GetAllAsync();
        }

        [HttpGet("PostsId")]
        public async Task<ActionResult<PostResponse>> GetAsync(int id)
        {
            return await _postService.GetByIdAsync(id);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] PostRequest request)
        {
            var isCreated = await _postService.AddAsync(request);

            if (!isCreated) return BadRequest();

            return Ok();
        }

        [HttpPut("Update")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(int id, [FromBody] PostRequest request)
        {
            var isUpdated = await _postService.UpdateAsync(id, request);

            if (!isUpdated) return BadRequest();

            return Ok();
        }

        [HttpDelete("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _postService.DeleteAsync(id);

            if (!isDeleted) return BadRequest();

            return Ok();
        }
    }
}
