using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class CourseSection : BaseEntity
{
	public int SectionNumber { get; set; }

	public string SectionName { get; set; }

	public int? TotalStep { get; set; }

	public string CourseId { get; set; }

	public bool Status { get; set; }

	[ForeignKey("CourseId")]
	public Course Course { get; set; }

	public ICollection<Step> Steps { get; set; }
}