using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using System.Collections.Generic;

namespace DUPSS.Application.Features.Blogs.Queries.GetAll
{
    public class GetAllBlogsQuery : IQuery<PagedResult<GetAllBlogsResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        // Title, Content, Description
        public string? Search { get; set; }

        // Title, CreatedAt, AuthorId
        public string? SortBy { get; set; }

        // "asc" or "desc"
        public string? SortOrder { get; set; }

        // AuthorId, Title
        public Dictionary<string, string>? Filters { get; set; }
    }
}
