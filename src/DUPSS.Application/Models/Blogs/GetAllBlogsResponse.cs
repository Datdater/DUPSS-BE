using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Blogs
{
    public record GetAllBlogsResponse(
         string Id,
         string Title,
         string? Content,
         string? Description,
         string AuthorId,
         DateTime CreatedAt
     );
}
