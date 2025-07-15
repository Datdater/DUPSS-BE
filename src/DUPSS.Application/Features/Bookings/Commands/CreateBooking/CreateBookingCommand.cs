using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : ICommand
    {
        public DateTime BookingDate { get; set; }

        public string? BookingNote { get; set; }
    }
}
