using DUPSS.Application.Features.Accounts.Queries.GetAllConsultant;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    public class AccountsController(IMediator mediator) : BaseAPIController
    {
        [HttpGet("consultants")]
        public async Task<IActionResult> GetAllConsultant()
        {
            var result = await mediator.Send(new GetAllConsultantQuery());
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Error);
        }
    }
}
