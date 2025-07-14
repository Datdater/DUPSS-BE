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

        // Search chung cho Title, Description, Content
        public string? Search { get; set; }

        // Sort fields
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }

        // Thay cho Dictionary
        public string? AuthorId { get; set; }
        public string? Title { get; set; }
    }

}
