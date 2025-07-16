using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.CourseRegistrations.Queries.CheckRegistration
{
    public class CheckRegistrationQueryHandler(IUnitOfWork unitOfWork, IClaimService service)
        : IQueryHandler<CheckRegistrationQuery, bool>
    {
        public async Task<Result<bool>> Handle(
            CheckRegistrationQuery request,
            CancellationToken cancellationToken
        )
        {
            var userId = service.GetCurrentUser;
            var courseRegistrationRepository = await unitOfWork
                .Repository<CourseRegistration>()
                .GetQueryable()
                .FirstOrDefaultAsync(cr =>
                    cr.CourseId == request.CourseId && cr.Student.Id == userId
                );
            ;
            if (courseRegistrationRepository is null)
            {
                return Result.Success(false);
            }
            return Result.Success(true);
        }
    }
}
