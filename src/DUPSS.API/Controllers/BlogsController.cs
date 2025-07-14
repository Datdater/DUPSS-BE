using DUPSS.Application.Features.Blogs.Commands.Create;
using DUPSS.Application.Features.Blogs.Commands.Update;
using DUPSS.Application.Features.Blogs.Queries.GetAll;
using DUPSS.Application.Features.Blogs.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs([FromQuery] GetAllBlogsQuery query)
        {
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(string id)
        {
            var query = new GetBlogByIdQuery { Id = id };
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetBlogById), new { id = result}, result);
            }
            return BadRequest(result.Error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(string id, [FromBody] UpdateBlogCommand command)
        {
            command.Id = id;
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound(result.Error);
        }
    }
}
