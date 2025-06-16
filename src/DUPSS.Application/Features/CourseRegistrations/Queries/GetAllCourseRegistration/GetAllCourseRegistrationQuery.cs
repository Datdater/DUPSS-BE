using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.CourseRegistrations;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;

namespace DUPSS.Application.Features.CourseRegistrations.Queries.GetAllCourseRegistration;

public class GetAllCourseRegistrationQuery : IQuery<PagedResult<GetAllCoursesRegistrationResponse>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; } = null;
}
