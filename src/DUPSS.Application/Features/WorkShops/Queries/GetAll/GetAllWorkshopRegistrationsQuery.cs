using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.WorkShops.Queries.GetAll
{
    public record GetAllWorkshopRegistrationsQuery(
     int PageIndex = 1,
     int PageSize = 10,
     string? Search = null,
     string? WorkshopId = null,
     string? UserId = null, 
     string? SortBy = null,
     string? SortOrder = null
) : IQuery<PagedResult<GetAllWorkshopRegistrationsResponse>>;

}
