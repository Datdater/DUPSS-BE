using DUPSS.Application.Features.Courses.Commands.Create;
using DUPSS.Application.Features.Courses.Commands.Update;
using DUPSS.Application.Features.Courses.Queries.GetById;
using DUPSS.Application.Features.QueuingCourses.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers;

public class QueuingCourseController(IMediator mediator) : BaseAPIController
{
    [HttpGet]
    public async Task<IActionResult> GetAllQueuingCourses(
        [FromQuery] GetAllQueuingCourseQuery query
    )
    {
        var result = await mediator.Send(query);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetQueuingCourseById(string id)
    {
        var query = new GetCourseByIdQuery() { Id = id };
        var result = await mediator.Send(query);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }

        return BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(string id, [FromBody] UpdateCourseCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Course ID mismatch.");
        }

        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    //[HttpPatch("{id}")]
    //public async Task<IActionResult> ApproveQueuingCourse(string id)
    //{

    //}
}
