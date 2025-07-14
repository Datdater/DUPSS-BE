using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Enums;

namespace DUPSS.Application.Features.CourseRegistrations.Commands.Create;

public class CreateCourseRegistrationCommand : ICommand
{
    public string CourseId { get; set; }
    public string StudentId { get; set; }
    public DateTime SellingDate { get; set; } = DateTime.Now;
    public DateTime CourseStartedDate { get; set; } = DateTime.Now;
    public double CourseProgress { get; set; } = 0;
    public CourseRegistrationStatus Status { get; set; } = CourseRegistrationStatus.Purchased;
    public string? CertificateFile { get; set; }
}
