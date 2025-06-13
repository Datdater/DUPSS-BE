using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.Blogs.Queries.GetById
{
    public class GetBlogByIdQuery : IQuery<GetBlogResponse>
    {
        public string Id { get; set; }
    }
}
