using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Bookings
{
    public class GetAllBookingByUserResponse
    {
        public string Id { get; set; } = string.Empty;
        public string BookingCode { get; set; } = string.Empty;
        public string? BookingNote { get; set; }
        public string? StaffName { get; set; }
        public DateTime BookingDate { get; set; }
        public string? MeetingUrl { get; set; }
        public string? Feedback { get; set; }
        public string? CancelReason { get; set; }
        public Domain.Enums.BookingStatus BookingStatus { get; set; }
    }
}
