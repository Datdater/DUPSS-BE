using DUPSS.Domain.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.Courses.Commands.Create
{
    public class CreateCourseCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
    }
}
