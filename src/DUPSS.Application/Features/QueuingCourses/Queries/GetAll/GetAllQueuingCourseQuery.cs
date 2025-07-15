using DUPSS.Application.Models.QueuingCourses;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;

namespace DUPSS.Application.Features.QueuingCourses.Queries.GetAll;

public class GetAllQueuingCourseQuery : IQuery<PagedResult<GetAllQueuingCoursesResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}
