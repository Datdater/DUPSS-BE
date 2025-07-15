using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Courses.Commands.Create.CourseTracking
{
    public class CreateCourseTrackingCommand : ICommand
    {
        public string StepId { get; set; } = string.Empty;
    }
}
