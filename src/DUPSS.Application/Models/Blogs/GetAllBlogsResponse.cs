using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Blogs
{
    public class GetAllBlogsResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public string? Description { get; set; }
        public string AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorName { get; set; }

        // Optional constructor (không bắt buộc)
        public GetAllBlogsResponse() { }
    }


}
