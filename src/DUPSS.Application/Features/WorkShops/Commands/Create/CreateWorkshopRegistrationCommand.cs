using DUPSS.Domain.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.WorkShops.Commands.Create
{
    public record CreateWorkshopRegistrationCommand(
        string WorkshopId,
        string UserId,
        string Note
    ) : ICommand;
}
