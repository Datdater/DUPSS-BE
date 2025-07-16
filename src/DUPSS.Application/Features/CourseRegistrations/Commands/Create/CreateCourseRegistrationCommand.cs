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
}
