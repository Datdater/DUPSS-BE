using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class Tracking : BaseEntity
{
    public string EnrollmentId { get; set; }
    public string StepId { get; set; }

    [ForeignKey("EnrollmentId")]
    public CourseRegistration CourseRegistration { get; set; }
    public Step Step { get; set; }
}
