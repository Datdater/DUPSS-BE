using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Courses;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;

namespace DUPSS.Application.Features.Courses.Queries.GetAll
{
    public class GetAllCoursesQuery : IQuery<PagedResult<GetAllCoursesResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
    }
}
