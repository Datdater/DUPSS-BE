using AutoMapper;
using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.WorkShops.Queries.GetById
{
    public class GetWorkshopRegistrationByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
       : IQueryHandler<GetWorkshopRegistrationByIdQuery, GetWorkshopRegistrationResponse>
    {
        public async Task<Result<GetWorkshopRegistrationResponse>> Handle(
            GetWorkshopRegistrationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await unitOfWork.Repository<WorkshopRegistration>().GetByIdAsync(request.Id);

            var response = mapper.Map<GetWorkshopRegistrationResponse>(entity);
            return Result.Success(response);
        }
    }
}
