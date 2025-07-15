using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Steps
{
    public class GetStepPreviewResponse
    {
        public string Id { get; set; } = string.Empty;
        public string StepSummary { get; set; } = string.Empty;
        public int StepNumber { get; set; }
        public string CourseSectionId { get; set; }
    }
}
