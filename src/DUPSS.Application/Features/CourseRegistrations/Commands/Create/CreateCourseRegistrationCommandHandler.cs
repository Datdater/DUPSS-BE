using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.CourseRegistrations.Commands.Create;

public class CreateCourseRegistrationCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCourseRegistrationCommand>
{
    public async Task<Result> Handle(
        CreateCourseRegistrationCommand request,
        CancellationToken cancellationToken
    )
    {
        // Check if course exists
        var course = await unitOfWork.Repository<Course>().GetByIdAsync(request.CourseId);
        if (course == null)
            return Result.Failure(
                new Error("CourseNotFound", "The specified course was not found.")
            );

        // Check if registration already exists
        var existingRegistrations = unitOfWork
            .Repository<CourseRegistration>()
            .GetQueryable()
            .Where(cr => cr.CourseId == request.CourseId && cr.StudentId == request.StudentId);

        if (await existingRegistrations.AnyAsync(cancellationToken))
            return Result.Failure(
                new Error("DuplicateRegistration", "Student is already registered for this course.")
            );

        var courseRegistration = new CourseRegistration
        {
            CourseId = request.CourseId,
            StudentId = request.StudentId,
            CourseStartedDate = DateTime.UtcNow,
        };

        await unitOfWork.Repository<CourseRegistration>().AddAsync(courseRegistration);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
