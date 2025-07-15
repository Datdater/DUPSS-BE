using DUPSS.Application.Features.WorkShops.Commands.Create;
using DUPSS.Application.Features.WorkShops.Commands.Update;
using DUPSS.Application.Features.WorkShops.Queries.GetAll;
using DUPSS.Application.Features.WorkShops.Queries.GetById;
using DUPSS.Domain.Abstractions.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkShopsController(IMediator mediator) : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllWorkshopsQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var query = new GetWorkshopByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkshopCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateWorkshopCommand command)
        {
            if (id != command.Id)
                return Ok(Result.Failure);

            var result = await mediator.Send(command);
            return Ok(result);
        }

        // Workshop Registrations 

        [HttpGet("registrations")]
        public async Task<IActionResult> GetAllRegistrations([FromQuery] GetAllWorkshopRegistrationsQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("registrations/{id}")]
        public async Task<IActionResult> GetRegistrationById(string id)
        {
            var query = new GetWorkshopRegistrationByIdQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("registrations")]
        public async Task<IActionResult> CreateRegistration([FromBody] CreateWorkshopRegistrationCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
