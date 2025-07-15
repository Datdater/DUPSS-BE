using DUPSS.Application.Features.Courses.Queries.GetById;
using DUPSS.Application.Features.QueuingCourses.Commands.Create;
using DUPSS.Application.Features.QueuingCourses.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers;

public class QueuingCourseController(IMediator mediator) : BaseAPIController
{
    [HttpGet]
    [Authorize(Roles = "Manager,Staff")]
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
    [Authorize(Roles = "Staff")]
    public async Task<IActionResult> CreateQueuingCourse(
        [FromBody] CreateQueuingCourseCommand command
    )
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            return Ok(result);
        }

        return BadRequest(result);
    }

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateCourse(string id, [FromBody] UpdateCourseCommand command)
    //{
    //    if (id != command.Id)
    //    {
    //        return BadRequest("Course ID mismatch.");
    //    }

    //    var result = await mediator.Send(command);
    //    if (result.IsSuccess)
    //    {
    //        return Ok(result);
    //    }

    //    return BadRequest(result);
    //}

    //[HttpPatch("{id}")]
    //public async Task<IActionResult> ApproveQueuingCourse(string id)
    //{

    //}
}
