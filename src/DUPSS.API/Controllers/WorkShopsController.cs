using DUPSS.Application.Features.WorkShops.Commands.Create;
using DUPSS.Application.Features.WorkShops.Commands.Update;
using DUPSS.Application.Features.WorkShops.Queries.GetAll;
using DUPSS.Application.Features.WorkShops.Queries.GetById;

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkShopsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllWorkshopsQuery query)
        {
            var result = await mediator.Send(query);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var query = new GetWorkshopByIdQuery(id);
            var result = await mediator.Send(query);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkshopCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateWorkshopCommand command)
        {
            if (id != command.Id)
                return BadRequest("Mismatched ID in URL and payload");

            var result = await mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        // Workshop Registrations 

        [HttpGet("registrations")]
        public async Task<IActionResult> GetAllRegistrations([FromQuery] GetAllWorkshopRegistrationsQuery query)
        {
            var result = await mediator.Send(query);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpGet("registrations/{id}")]
        public async Task<IActionResult> GetRegistrationById(string id)
        {
            var query = new GetWorkshopRegistrationByIdQuery(id);
            var result = await mediator.Send(query);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }

        [HttpPost("registrations")]
        public async Task<IActionResult> CreateRegistration([FromBody] CreateWorkshopRegistrationCommand command)
        {
            var result = await mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }
    }
}
