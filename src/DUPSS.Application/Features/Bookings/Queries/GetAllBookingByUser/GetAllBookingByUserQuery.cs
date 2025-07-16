using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Bookings;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Bookings.Queries.GetAllBookingByUser
{
    public class GetAllBookingByUserQuery : IQuery<List<GetAllBookingByUserResponse>> { }
}
