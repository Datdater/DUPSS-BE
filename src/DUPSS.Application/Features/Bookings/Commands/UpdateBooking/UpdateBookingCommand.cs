using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Enums;

namespace DUPSS.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommand : ICommand
    {
        public required string BookingCode { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public string? StaffId { get; set; }
        public string? MeetingUrl { get; set; }
        public string? Feedback { get; set; }
        public string? CancelReason { get; set; }
    }
}
