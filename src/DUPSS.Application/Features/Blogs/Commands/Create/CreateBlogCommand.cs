using DUPSS.Domain.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.Blogs.Commands.Create
{
    public class CreateBlogCommand : ICommand
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string AuthorId { get; set; } = default!;
    }
}
