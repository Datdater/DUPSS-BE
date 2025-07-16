using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Steps;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Steps.Queries.GetDetailStepTracking
{
    public class GetDetailStepTrackingQuery : IQuery<GetDetailTrackingResponse>
    {
        public string StepId { get; set; } = string.Empty;
    }
}
