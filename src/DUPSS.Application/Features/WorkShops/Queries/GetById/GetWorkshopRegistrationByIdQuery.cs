using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.WorkShops.Queries.GetById
{
    public record GetWorkshopRegistrationByIdQuery(string Id)
        : IQuery<GetWorkshopRegistrationResponse>;
}
