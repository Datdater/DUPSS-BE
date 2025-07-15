using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DUPSS.Application.Models.Courses;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Courses.Queries.GetAll;

public class GetAllCoursesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetAllCoursesQuery, PagedResult<GetAllCoursesResponse>>
{
    public async Task<Result<PagedResult<GetAllCoursesResponse>>> Handle(
        GetAllCoursesQuery request,
        CancellationToken cancellationToken
    )
    {
        var queryable = unitOfWork
            .Repository<Course>()
            .GetQueryable()
            .Include(x => x.Category)
            .Where(x => x.Status);
        if (!string.IsNullOrEmpty(request.Search))
        {
            queryable = queryable.Where(c =>
                c.CourseName.Contains(request.Search) || c.CourseCode.Contains(request.Search)
            );
        }
        var cousers = await PagedResult<Course>.CreateAsync(
            queryable,
            request.PageIndex,
            request.PageSize
        );
        var response = mapper.Map<PagedResult<GetAllCoursesResponse>>(cousers);
        return Result.Success(response);
    }
}
