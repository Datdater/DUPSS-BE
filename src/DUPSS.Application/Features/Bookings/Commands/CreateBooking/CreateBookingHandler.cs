using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using DUPSS.Application.Services;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Enums;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingHandler(
        IUnitOfWork unitOfWork,
        IClaimService claimService,
        IGenerateUniqueCode generateUniqueCode
    ) : ICommandHandler<CreateBookingCommand>
    {
        public Task<Result> Handle(
            CreateBookingCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var userId = claimService.GetCurrentUser;

                var bookingRepository = unitOfWork.Repository<BookingRequest>();
                var bookingCode = generateUniqueCode
                    .GenerateUniqueCodeAsync(
                        bookingRepository,
                        b => b.BookingCode,
                        7 // Assuming the default length is 7
                    )
                    .Result;

                var booking = new BookingRequest
                {
                    BookingCode = bookingCode,
                    UserId = userId,
                    BookingDate = request.BookingDate,
                    BookingNote = request.BookingNote,
                };
                booking.SetPendingStatus();
                bookingRepository.AddAsync(booking);
                return unitOfWork
                    .SaveChangesAsync(cancellationToken)
                    .ContinueWith(t => Result.Success(), cancellationToken);
            }
            catch (Exception ex)
            {
                return Task.FromResult(
                    Result.Failure(new Error("Error.BookingCreation", ex.Message))
                );
            }
        }
    }
}
