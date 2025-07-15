using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.CourseRegistrations.Queries.CheckRegistration
{
    public class CheckRegistrationQuery : IQuery<bool>
    {
        public string CourseId { get; set; }
    }
}
