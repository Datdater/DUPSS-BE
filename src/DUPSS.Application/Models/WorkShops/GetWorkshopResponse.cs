using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.WorkShops
{
    public record GetWorkshopResponse(
       string Id,
       string Title,
       string? Description,
       string? ImageUrl,
       DateTime StartDate,
       DateTime EndDate,
       string Host,
       bool Status
   );
}
