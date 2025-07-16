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
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var booking = await unitOfWork
                    .Repository<BookingRequest>()
                    .GetQueryable()
                    .FirstOrDefaultAsync(
                        x => x.BookingCode == request.BookingCode,
                        cancellationToken
                    );
                if (booking == null)
                {
                    return Result.Failure(new Error("Error.BookingNotFound", "Booking not found."));
                }
                switch (request.BookingStatus)
                {
                    case Domain.Enums.BookingStatus.Approved:
                        booking.ApproveBooking(
                            request.StaffId
                                ?? throw new ArgumentNullException(nameof(request.StaffId)),
                            request.MeetingUrl
                        );
                        break;
                    case Domain.Enums.BookingStatus.Completed:
                        booking.CompleteBooking(request.Feedback);
                        break;
                    case Domain.Enums.BookingStatus.Cancelled:
                        if (
                            booking.Status == Domain.Enums.BookingStatus.Approved
                            || booking.Status == Domain.Enums.BookingStatus.Completed
                        )
                        {
                            return Result.Failure(
                                new Error(
                                    "Error.BookingCannotBeCancelled",
                                    "Cannot cancel a booking that has already been approved or completed."
                                )
                            );
                        }

                        booking.CancelBooking(
                            request.CancelReason
                                ?? throw new ArgumentNullException(nameof(request.CancelReason))
                        );
                        break;
                }
                await unitOfWork.Repository<BookingRequest>().UpdateAsync(booking);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                await unitOfWork.CommitTransactionAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransactionAsync();
                return Result.Failure(new Error("Error.BookingUpdate", ex.Message));
            }
        }
    }
}
