using AutoMapper;
using DUPSS.Application.Models.QueuingCourses;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.QueuingCourses.Queries.GetAll;

public class GetAllQueuingCourseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetAllQueuingCourseQuery, PagedResult<GetAllQueuingCoursesResponse>>
{
    public async Task<Result<PagedResult<GetAllQueuingCoursesResponse>>> Handle(
        GetAllQueuingCourseQuery request,
        CancellationToken cancellationToken
    )
    {
        var queryable = unitOfWork.Repository<QueuingCourse>().GetQueryable();

        if (!string.IsNullOrEmpty(request.Search))
        {
            queryable = queryable.Where(c =>
                c.CourseName.Contains(request.Search) || c.CourseCode.Contains(request.Search)
            );
        }

        var queuingCourses = await PagedResult<QueuingCourse>.CreateAsync(
            queryable,
            request.PageIndex,
            request.PageSize
        );

        var res = mapper.Map<PagedResult<GetAllQueuingCoursesResponse>>(queuingCourses);
        return Result.Success(res);
    }
}
