using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Steps;

namespace DUPSS.Application.Models.CourseSections
{
    public class GetCourseSectionResponse
    {
        public string Id { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public bool Status { get; set; }
        public List<GetStepPreviewResponse> Steps { get; set; } =
            new List<GetStepPreviewResponse>();
    }
}
