using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Bookings;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Enums;

namespace DUPSS.Application.Features.Bookings.Queries.GetAllBookingByUser
{
    public class GetAllBookingQuery : IQuery<PagedResult<GetAllBookingResponse>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Search { get; set; }

        public BookingStatus? BookingStatus { get; set; }
    }
}
