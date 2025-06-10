using DUPSS.Application.Features.Courses.Queries.GetAll;
using DUPSS.Application.Models.Blogs;
using DUPSS.Application.Models.Courses;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.Blogs.Queries.GetAll
{
    public class GetAllBlogsQuery : IQuery<PagedResult<GetAllBlogsResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }
}
