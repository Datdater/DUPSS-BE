using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DUPSS.Application.Models.Steps;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Steps.Queries.GetDetailStepTracking
{
    public class GetDetailStepTrackingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetDetailStepTrackingQuery, GetDetailTrackingResponse>
    {
        public async Task<Domain.Abstractions.Shared.Result<GetDetailTrackingResponse>> Handle(
            GetDetailStepTrackingQuery request,
            CancellationToken cancellationToken
        )
        {
            var step = await unitOfWork
                .Repository<Domain.Entities.Step>()
                .GetQueryable()
                .FirstOrDefaultAsync(x => x.Id == request.StepId);
            var response = mapper.Map<GetDetailTrackingResponse>(step);
            return Result.Success(response);
        }
    }
}
