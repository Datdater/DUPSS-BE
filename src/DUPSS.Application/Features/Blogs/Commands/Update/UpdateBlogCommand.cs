using DUPSS.Domain.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.Blogs.Commands.Update
{
    public class UpdateBlogCommand : ICommand
    {
        public string Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string? Content { get; set; }
    }
}
