using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.WorkShops
{
    public record GetAllWorkshopRegistrationsResponse(
     string Id,
     string WorkshopId,
     string WorkshopTitle,
     string UserId,
     string UserName,
     string Note
 );
}
