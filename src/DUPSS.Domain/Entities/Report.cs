using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class Report : BaseEntity
{
    public string? Issue { get; set; }
    public string? Content { get; set; }
    public string? Attachment { get; set; }
    public string CourseId { get; set; }
    public string Status { get; set; }

    public Course Course { get; set; }
}
