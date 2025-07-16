using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;

namespace DUPSS.Application.Features.WorkShops.Queries.GetAllWorkshopRegistrationByUser
{
    public class GetAllWorkshopRegistrationByUserQuery
        : IQuery<PagedResult<GetAllWorkshopsResponse>>
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;
        public string? Search { get; set; }

        public DateOnly? StartDate { get; set; }
    }
}
