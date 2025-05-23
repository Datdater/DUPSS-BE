using DUPSS.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Entities
{
    public class QueuingCourseSection : BaseEntity
    {
        public int SectionNumber { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public int? TotalStep { get; set; }
        public string QueuingCoureseId { get; set; }
        public QueuingCourse QueuingCourese { get; set; } = null!;
        public ICollection<QueuingStep> Steps { get; set; } = new List<QueuingStep>();
    }
}
