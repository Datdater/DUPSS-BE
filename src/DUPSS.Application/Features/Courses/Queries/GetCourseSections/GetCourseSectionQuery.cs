using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.CourseSections;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Courses.Queries.GetCourseSections
{
    public class GetCourseSectionQuery : IQuery<List<GetCourseSectionResponse>>
    {
        public string CourseId { get; set; }
    }
}
