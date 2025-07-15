using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Steps
{
    public class GetDetailTrackingResponse
    {
        public string Id { get; set; } = string.Empty;
        public int StepNumber { get; set; }

        public string StepSummary { get; set; }

        public string? Content { get; set; }

        public bool Status { get; set; }

        [MaxLength(500)]
        public string? Attachment { get; set; }

        public string CourseSectionId { get; set; }

        public int? Duration { get; set; }

        public bool Type { get; set; }

        public string? VideoURL { get; set; }
    }
}
