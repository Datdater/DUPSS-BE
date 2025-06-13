using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Domain.Commons;
using DUPSS.Domain.Enums;

namespace DUPSS.Domain.Entities
{
    public class QueuingCourse : BaseEntity
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string PictureUrl { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string AttachmentUrl { get; set; }
        public int TotalDuration { get; set; }
        public int TotalSection { get; set; }
        public int TotalStep { get; set; }
        public QueuingCourseStatus QueuingCourseStatus { get; set; }

        public ICollection<Reason> Reasons { get; set; } = new List<Reason>();
    }
}
