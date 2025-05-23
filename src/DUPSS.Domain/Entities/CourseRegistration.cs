using DUPSS.Domain.Commons;
using DUPSS.Domain.Enums;

namespace DUPSS.Domain.Entities;

public class CourseRegistration : BaseEntity
{
	public string CourseId { get; set; }
	public string StudentId { get; set; }
	public DateTime SellingDate { get; set; }
	public DateTime CourseStartedDate { get; set; }
	public double CourseProgress { get; set; }
	public CourseRegistrationStatus Status { get; set; }
	public string? CertificateFile { get; set; }

	public Course Course { get; set; }
	public AppUser Student { get; set; }
	public ICollection<Tracking> Trackings { get; set; }
}