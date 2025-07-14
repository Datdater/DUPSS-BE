using DUPSS.Application.Features.Authentications.Commands.Login;
using DUPSS.Application.Features.Authentications.Commands.Register;
using DUPSS.Application.Features.Courses.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController(IMediator mediator) : BaseAPIController
	{
		[HttpPost("/register")]
		public async Task<IActionResult> Register([FromBody] RegisterCommand command)
		{
			var result = await mediator.Send(command);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result.Error);
		}
		[HttpPost("/login")]
		public async Task<IActionResult> Login([FromBody] LoginCommand command)
		{
			var result = await mediator.Send(command);
			if (result.IsSuccess)
			{
				return Ok(result);
			}
			return BadRequest(result.Error);
		}
	}
}