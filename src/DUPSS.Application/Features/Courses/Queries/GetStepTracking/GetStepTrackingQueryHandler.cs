using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using DUPSS.Application.Models.Steps;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Courses.Queries.GetStepTracking
{
    public class GetStepTrackingQueryHandler(IUnitOfWork unitOfWork, IClaimService claimService)
        : IQueryHandler<GetStepTrackingQuery, List<GetStepPreviewResponse>>
    {
        public async Task<Result<List<GetStepPreviewResponse>>> Handle(
            GetStepTrackingQuery request,
            CancellationToken cancellationToken
        )
        {
            var userId = claimService.GetCurrentUser;
            var stepTracking = await unitOfWork
                .Repository<Tracking>()
                .GetQueryable()
                .Include(x => x.Step)
                .Include(x => x.CourseRegistration)
                .Include(x => x.CourseRegistration.Student)
                .Where(x =>
                    x.CourseRegistration.Course.Id == request.CourseId
                    && x.CourseRegistration.Student.Id == userId
                )
                .ToListAsync(cancellationToken);

            var steps = stepTracking
                .Select(x => new GetStepPreviewResponse
                {
                    Id = x.Step.Id,
                    StepSummary = x.Step.StepSummary,
                    CourseSectionId = x.Step.CourseSectionId,
                    StepNumber = x.Step.StepNumber,
                })
                .OrderBy(x => x.StepNumber)
                .ToList();
            return Result.Success(steps);
        }
    }
}
