using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Courses.Commands.Create;

public class CreateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<CreateCourseCommand>
{
    public async Task<Result> Handle(
        CreateCourseCommand request,
        CancellationToken cancellationToken
    )
    {
        var course = new Course
        {
            CourseName = request.CourseName,
            CourseCode = request.CourseCode,
            PictureURL = request.PictureURL,
            Summary = request.Summary,
            Content = request.Content,
            Attachment = request.Attachment,
            Status = request.Status,
            TotalDuration = request.TotalDuration,
            TotalSection = request.TotalSection,
            TotalStep = request.TotalStep,
            CategoryId = request.CategoryId,
        };
        await unitOfWork.Repository<Course>().AddAsync(course);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
