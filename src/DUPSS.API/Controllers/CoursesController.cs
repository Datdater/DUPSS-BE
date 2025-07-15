using DUPSS.Application.Features.CourseRegistrations.Queries.CheckRegistration;
using DUPSS.Application.Features.Courses.Commands.Create;
using DUPSS.Application.Features.Courses.Commands.Create.CourseTracking;
using DUPSS.Application.Features.Courses.Commands.Update;
using DUPSS.Application.Features.Courses.Queries.GetAll;
using DUPSS.Application.Features.Courses.Queries.GetById;
using DUPSS.Application.Features.Courses.Queries.GetCourseSections;
using DUPSS.Application.Features.Courses.Queries.GetStepTracking;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers;

public class CoursesController(IMediator mediator) : BaseAPIController
{
    [HttpGet]
    public async Task<IActionResult> GetAllCourses([FromQuery] GetAllCoursesQuery query)
    {
        var result = await mediator.Send(query);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
    {
        var result = await mediator.Send(command);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(string id)
    {
        var query = new GetCourseByIdQuery() { Id = id };
        var result = await mediator.Send(query);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result.Error);
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
        return BadRequest(result.Error);
    }

    [HttpGet("{id}/course-sections")]
    public async Task<IActionResult> GetCourseSectionsByCourseId(string id)
    {
        var query = new GetCourseSectionQuery() { CourseId = id };
        var result = await mediator.Send(query);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result.Error);
    }

    [HttpGet("{id}/step-trackings")]
    public async Task<IActionResult> GetCourseStepTrackingsByCourseId(string id)
    {
        var query = new GetStepTrackingQuery() { CourseId = id };
        var result = await mediator.Send(query);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result.Error);
    }

    [HttpGet("{id}/check-registration")]
    [Authorize]
    public async Task<IActionResult> CheckCourseRegistration(string id)
    {
        var query = new CheckRegistrationQuery() { CourseId = id };
        var result = await mediator.Send(query);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result.Error);
    }
}
