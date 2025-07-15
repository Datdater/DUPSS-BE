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

namespace DUPSS.Application.Features.Courses.Commands.Create.CourseTracking
{
    public class CreateCourseTrackingCommandHandler(IUnitOfWork unitOfWork, IClaimService service)
        : ICommandHandler<CreateCourseTrackingCommand>
    {
        public async Task<Result> Handle(
            CreateCourseTrackingCommand request,
            CancellationToken cancellationToken
        )
        {
            var userId = service.GetCurrentUser;
            var step = await unitOfWork
                .Repository<Step>()
                .GetQueryable()
                .Include(c => c.CourseSection)
                .ThenInclude(cs => cs.Course)
                .FirstOrDefaultAsync(c => c.Id == request.StepId, cancellationToken);
            var course = step?.CourseSection?.Course;
            // Check if course registration exists
            var enrollment = await unitOfWork
                .Repository<CourseRegistration>()
                .GetQueryable()
                .Include(cr => cr.Student)
                .Include(cr => cr.Course)
                .FirstOrDefaultAsync(
                    cr => cr.Course.Id == course.Id && cr.Student.Id == userId,
                    cancellationToken
                );
            var stepTracking = new Tracking
            {
                StepId = request.StepId,
                EnrollmentId = enrollment?.Id,
                CreatedAt = DateTime.UtcNow,
            };
            await unitOfWork.Repository<Tracking>().AddAsync(stepTracking);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
