using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.WorkShops.Commands.Registration
{
    public class WorkshopRegistrationCommand : ICommand
    {
        public string? Note { get; set; }

        public string WorkshopId { get; set; } = string.Empty;
    }
}
