using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class QueuingCourseSection : BaseEntity
{
    public int SectionNumber { get; set; }
    public string SectionName { get; set; } = string.Empty;
    public int? TotalStep { get; set; }
    public string QueuingCourseId { get; set; }
    public QueuingCourse QueuingCourse { get; set; } = null!;
    public ICollection<QueuingStep> Steps { get; set; } = new List<QueuingStep>();
}
