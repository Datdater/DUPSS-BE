using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.Courses.Commands.Update;

public class UpdateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<UpdateCourseCommand>
{
    public async Task<Result> Handle(
        UpdateCourseCommand request,
        CancellationToken cancellationToken
    )
    {
        var course = await unitOfWork.Repository<Course>().GetByIdAsync(request.Id);
        if (course == null)
        {
            throw new CourseException.CourseNotFoundException(request.Id);
        }
        course.CourseName = request.CourseName;
        course.CourseCode = request.CourseCode;
        course.PictureURL = request.PictureURL;
        course.Summary = request.Summary;
        course.Content = request.Content;
        course.Attachment = request.Attachment;
        course.Status = request.Status;
        course.TotalDuration = request.TotalDuration;
        course.TotalSection = request.TotalSection;
        course.TotalStep = request.TotalStep;
        course.CategoryId = request.CategoryId;

        await unitOfWork.Repository<Course>().UpdateAsync(course);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
