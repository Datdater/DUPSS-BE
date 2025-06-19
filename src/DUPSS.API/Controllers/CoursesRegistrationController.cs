using DUPSS.Application.Features.CourseRegistrations.Commands.Create;
using DUPSS.Application.Features.CourseRegistrations.Commands.Update;
using DUPSS.Application.Features.CourseRegistrations.Queries.GetAllCourseRegistration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers;

public class CoursesRegistrationController(IMediator mediator) : BaseAPIController
{
    [HttpPost]
    public async Task<IActionResult> RegisterCourse(
        [FromBody] CreateCourseRegistrationCommand command
    )
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourseRegistration(
        string id,
        [FromBody] UpdateCourseRegistrationCommand command
    )
    {
        if (id != command.Id)
        {
            return BadRequest("Registration ID mismatch.");
        }
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<IActionResult> GetCourseRegistrationById(GetAllCourseRegistrationQuery query)
    {
        var result = await mediator.Send(query);
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return BadRequest(result.Error);
    }
}
