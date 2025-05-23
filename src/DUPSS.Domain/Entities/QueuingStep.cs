using DUPSS.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Entities
{
    public class QueuingStep : BaseEntity
    {
        public int StepNumber { get; set; }

        public string StepSummary { get; set; }

        public string? Content { get; set; }

        public string? Attachment { get; set; }

        public string CourseSectionId { get; set; }

        public int? Duration { get; set; }

        public bool Type { get; set; }

        [MaxLength(500)]
        public string? VideoURL { get; set; }
        public QueuingCourseSection QueuingCourese { get; set; } = null!;
    }
    
}
