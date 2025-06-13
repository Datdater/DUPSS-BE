using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Courses.Commands.Create
{
    public class CreateCourseCommand : ICommand
    {
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
        public string? CategoryId { get; set; }
    }
}
