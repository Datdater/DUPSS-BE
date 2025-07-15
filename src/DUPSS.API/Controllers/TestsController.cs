using DUPSS.Application.Features.Tests.Commands.Create;
using DUPSS.Application.Features.Tests.Commands.Update;
using DUPSS.Application.Features.Tests.Queries.GetAll;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController(IMediator mediator) : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTests([FromQuery] GetAllTestsQuery query)
        {
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest([FromBody] CreateTestCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTest(string id, [FromBody] UpdateTestCommand command)
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
