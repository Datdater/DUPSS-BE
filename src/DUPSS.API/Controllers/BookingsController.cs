using DUPSS.Application.Features.Bookings.Commands.CreateBooking;
using DUPSS.Application.Features.Bookings.Commands.UpdateBooking;
using DUPSS.Application.Features.Bookings.Queries.GetAllBookingByUser;
using DUPSS.Application.Features.Courses.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    public class BookingsController(IMediator mediator) : BaseAPIController
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Created(string.Empty, result);
            }
            return BadRequest(result);
        }

        [HttpGet("my-bookings")]
        [Authorize]
        public async Task<IActionResult> GetBookingByUser()
        {
            var result = await mediator.Send(new GetAllBookingByUserQuery());
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings([FromQuery] GetAllBookingQuery query)
        {
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateBooking(
            [FromRoute] string code,
            [FromBody] UpdateBookingCommand command
        )
        {
            command.BookingCode = code;
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
