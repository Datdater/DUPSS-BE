using AutoMapper;
using DUPSS.Application.Abtractions;
using DUPSS.Application.Models.QueuingCourses;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.QueuingCourses.Queries.GetAll;

public class GetAllQueuingCourseQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IClaimService claimService
) : IQueryHandler<GetAllQueuingCourseQuery, PagedResult<GetAllQueuingCoursesResponse>>
{
    public async Task<Result<PagedResult<GetAllQueuingCoursesResponse>>> Handle(
        GetAllQueuingCourseQuery request,
        CancellationToken cancellationToken
    )
    {
        var userId = claimService.GetCurrentUser;
        var userRole = claimService.GetCurrentRole;

        var queryable = unitOfWork.Repository<QueuingCourse>().GetQueryable();

        if (userRole == "Staff")
        {
            queryable = queryable.Where(c => c.CreatedBy == userId);
        }

        if (!string.IsNullOrEmpty(request.Search))
        {
            queryable = queryable.Where(c =>
                c.CourseName.Contains(request.Search) || c.CourseCode.Contains(request.Search)
            );
        }
        queryable = queryable.Include(x => x.Category).Include(x => x.User);

        var queuingCourses = await PagedResult<QueuingCourse>.CreateAsync(
            queryable,
            request.PageIndex,
            request.PageSize
        );

        var res = mapper.Map<PagedResult<GetAllQueuingCoursesResponse>>(queuingCourses);

        return Result.Success(res);
    }
}
