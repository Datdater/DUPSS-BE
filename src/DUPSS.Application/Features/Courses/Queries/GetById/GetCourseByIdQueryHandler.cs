using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DUPSS.Application.Models.Courses;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Courses.Queries.GetById;

public class GetCourseByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<GetCourseByIdQuery, GetCourseResponse>
{
    public async Task<Result<GetCourseResponse>> Handle(
        GetCourseByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var course = await unitOfWork.Repository<Course>().GetByIdAsync(request.Id);
        if (course == null)
        {
            throw new CourseException.CourseNotFoundException(request.Id);
        }
        var response = mapper.Map<GetCourseResponse>(course);
        var ratings = await unitOfWork
            .Repository<Feedback>()
            .GetQueryable()
            .Where(x => x.CourseId == request.Id)
            .CountAsync(cancellationToken);
        response.RatingCount = ratings;
        if (ratings == 0)
        {
            response.RatingAverage = null;
            return Result.Success(response);
        }
        var averageRating = await unitOfWork
            .Repository<Feedback>()
            .GetQueryable()
            .Where(x => x.CourseId == request.Id)
            .AverageAsync(x => x.Rating, cancellationToken);
        response.RatingAverage = (float?)averageRating;
        return Result.Success(response);
    }
}
