using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Enums;

namespace DUPSS.Application.Features.CourseRegistrations.Commands.Update
{
    public class UpdateCourseRegistrationCommand : ICommand
    {
        public string Id { get; set; }
        public double CourseProgress { get; set; }
        public CourseRegistrationStatus Status { get; set; }
        public string? CertificateFile { get; set; }
    }
}
