using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Courses
{
    public class GetCourseResponse
    {
        public string Id { get; set; }
        public string CourseName { get; set; }
        public string? CourseCode { get; set; }

        public string? PictureURL { get; set; }

        public string? Summary { get; set; }

        public string? Content { get; set; }

        public string? Attachment { get; set; }
        public bool Status { get; set; }
        public int? TotalDuration { get; set; }
        public int? TotalSection { get; set; }
        public int? TotalStep { get; set; }

    }
}
