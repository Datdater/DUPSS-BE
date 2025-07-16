using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DUPSS.Application.Abtractions;
using DUPSS.Application.Models.Bookings;
using DUPSS.Application.Services;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Bookings.Queries.GetAllBookingByUser
{
    public class GetAllBookingByUserHandler(IUnitOfWork unitOfWork, IClaimService claimService)
        : IQueryHandler<GetAllBookingByUserQuery, List<GetAllBookingByUserResponse>>
    {
        public async Task<Result<List<GetAllBookingByUserResponse>>> Handle(
            GetAllBookingByUserQuery request,
            CancellationToken cancellationToken
        )
        {
            var userId = claimService.GetCurrentUser;

            var bookings = await unitOfWork
                .Repository<BookingRequest>()
                .GetQueryable()
                .Include(x => x.Staff)
                .Where(x => x.UserId == userId)
                .ToListAsync();
            var response = bookings
                .Select(x => new GetAllBookingByUserResponse
                {
                    Id = x.Id,
                    BookingCode = x.BookingCode,
                    BookingDate = DateTime.SpecifyKind(x.BookingDate, DateTimeKind.Utc),
                    BookingNote = x.BookingNote,
                    StaffName = x.Staff?.GetUserFullname(),
                    BookingStatus = x.Status,
                    MeetingUrl = x.UrlMeeting,
                    Feedback = x.BookingFeedback,
                    CancelReason = x.CancelReason,
                })
                .ToList();
            return Result.Success(response);
        }
    }
}
