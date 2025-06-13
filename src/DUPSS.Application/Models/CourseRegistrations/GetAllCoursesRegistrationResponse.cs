using DUPSS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.CourseRegistrations
{
    public class GetAllCoursesRegistrationResponse
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string StudentId { get; set; }
        public DateTime SellingDate { get; set; }
        public DateTime CourseStartedDate { get; set; }
        public double CourseProgress { get; set; }
        public CourseRegistrationStatus Status { get; set; }
        public string? CertificateFile { get; set; }

        // Navigation properties
        public string CourseName { get; set; }
        public string StudentName { get; set; }

    }
}
