using AutoMapper;
using DUPSS.Application.Abtractions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.QueuingCourses.Commands.Approve;

public class ApproveQueuingCourseCommandHandler(
    IUnitOfWork unitOfWork,
    IClaimService claimService,
    IMapper mapper
) : ICommandHandler<ApproveQueuingCourseCommand>
{
    public async Task<Result> Handle(
        ApproveQueuingCourseCommand request,
        CancellationToken cancellationToken
    )
    {
        await unitOfWork.BeginTransactionAsync();
        var userId = claimService.GetCurrentUser;

        var queuingCourse = await unitOfWork
            .Repository<QueuingCourse>()
            .GetQueryable()
            .FirstOrDefaultAsync(x => x.CourseCode == request.Code);

        if (queuingCourse == null)
        {
            throw new QueuingCourseException.QueuingCourseNotFoundException(request.Code);
        }

        if (queuingCourse.QueuingCourseStatus != QueuingCourseStatus.Pending)
        {
            throw new QueuingCourseException.QueuingCourseAlreadyApprovedException(
                queuingCourse.CourseCode
            );
        }

        queuingCourse.UpdatedDate = DateTime.Now;

        if (request.QueuingCourseStatus == QueuingCourseStatus.Reject)
        {
            queuingCourse.QueuingCourseStatus = QueuingCourseStatus.Reject;
        }
        else if (request.QueuingCourseStatus == QueuingCourseStatus.Approved)
        {
            queuingCourse.QueuingCourseStatus = QueuingCourseStatus.Approved;
            var course = mapper.Map<Course>(queuingCourse);
            var existedCourse = await unitOfWork
                .Repository<Course>()
                .GetQueryable()
                .FirstOrDefaultAsync(x => x.CourseCode == course.CourseCode);

            if (existedCourse == null)
            {
                await unitOfWork.Repository<Course>().AddAsync(course);
            }
            else
            {
                await unitOfWork.Repository<Course>().UpdateAsync(course);
            }
        }

        await unitOfWork.Repository<QueuingCourse>().UpdateAsync(queuingCourse);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        await unitOfWork.CommitTransactionAsync();

        return Result.Success();
    }
}
