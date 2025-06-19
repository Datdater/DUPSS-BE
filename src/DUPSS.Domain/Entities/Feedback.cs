using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class Feedback : BaseEntity
{
    public string? Detail { get; set; }
    public int Rating { get; set; }
    public string? Attachment { get; set; }
    public string CourseId { get; set; }
    public bool Status { get; set; }

    public Course Course { get; set; }
}
