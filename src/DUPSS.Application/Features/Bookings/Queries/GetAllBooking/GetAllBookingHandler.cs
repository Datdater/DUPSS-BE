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
    public class GetAllBookingHandler(IUnitOfWork unitOfWork)
        : IQueryHandler<GetAllBookingQuery, PagedResult<GetAllBookingResponse>>
    {
        public async Task<Result<PagedResult<GetAllBookingResponse>>> Handle(
            GetAllBookingQuery request,
            CancellationToken cancellationToken
        )
        {
            var bookingsQuery = unitOfWork
                .Repository<BookingRequest>()
                .GetQueryable()
                .Include(x => x.Staff)
                .Include(x => x.User)
                .Where(x =>
                    string.IsNullOrEmpty(request.Search)
                    || (
                        x.User != null
                        && (
                            x.User.FirstName.Contains(request.Search)
                            || x.User.LastName.Contains(request.Search)
                            || x.User.PhoneNumber.Contains(request.Search)
                        )
                    )
                )
                .Where(x =>
                    !request.BookingStatus.HasValue || x.Status == request.BookingStatus.Value
                )
                .Select(x => new GetAllBookingResponse
                {
                    Id = x.Id,
                    BookingCode = x.BookingCode,
                    BookingDate = x.BookingDate,
                    BookingNote = x.BookingNote,
                    StaffName = x.Staff != null ? x.Staff.GetUserFullname() : null,
                    BookingStatus = x.Status,
                    MeetingUrl = x.UrlMeeting,
                    Feedback = x.BookingFeedback,
                    CancelReason = x.CancelReason,
                    CustomerName = x.User != null ? x.User.GetUserFullname() : null,
                    CustomerPhoneNumber = x.User != null ? x.User.PhoneNumber : null,
                });

            var pagedResponse = await PagedResult<GetAllBookingResponse>.CreateAsync(
                bookingsQuery,
                request.PageIndex,
                request.PageSize
            );

            return Result.Success(pagedResponse);
        }
    }
}
