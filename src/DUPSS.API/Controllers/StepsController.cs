using DUPSS.Application.Features.Steps.Queries.GetDetailStepTracking;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    public class StepsController(IMediator mediator) : BaseAPIController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStepTracking(string id)
        {
            var query = new GetDetailStepTrackingQuery() { StepId = id };
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }
    }
}
