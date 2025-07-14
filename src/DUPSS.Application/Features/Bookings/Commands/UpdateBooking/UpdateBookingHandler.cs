using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingHandler(IUnitOfWork unitOfWork)
        : ICommandHandler<UpdateBookingCommand>
    {
        public async Task<Result> Handle(
            UpdateBookingCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var booking = await unitOfWork
                    .Repository<BookingRequest>()
                    .GetQueryable()
                    .FirstOrDefaultAsync(x => x.BookingCode == request.BookingCode);
                if (booking == null)
                {
                    return Result.Failure(new Error("Error.BookingNotFound", "Booking not found."));
                }
                if (request.StaffId != null)
                    booking.StaffId = request.StaffId;
                booking.Status = request.BookingStatus;
                await unitOfWork.Repository<BookingRequest>().UpdateAsync(booking);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(new Error("Error.BookingUpdate", ex.Message));
            }
        }
    }
}
