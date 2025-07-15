using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Steps;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Courses.Queries.GetStepTracking
{
    public class GetStepTrackingQuery : IQuery<List<GetStepPreviewResponse>>
    {
        public string CourseId { get; set; }
    }
}
