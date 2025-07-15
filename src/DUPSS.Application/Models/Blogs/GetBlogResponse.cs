using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Blogs
{
    public record GetBlogResponse
    {
        public string Id { get; init; }
        public string Title { get; init; }
        public string? Content { get; init; }
        public string? Description { get; init; }
        public string AuthorId { get; init; }
        public DateTime CreatedAt { get; init; }
        public string AuthorName { get; init; }

        public GetBlogResponse() { }
    }

}
