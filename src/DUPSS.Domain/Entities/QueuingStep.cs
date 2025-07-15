using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class QueuingStep : BaseEntity
{
    public int StepNumber { get; set; }

    public string StepSummary { get; set; }

    public string? Content { get; set; }

    public string? Attachment { get; set; }

    public int? Duration { get; set; }

    public bool Type { get; set; }

    [MaxLength(500)]
    public string? VideoURL { get; set; }

    public string? QueuingCourseSectionId { get; set; }
    public QueuingCourseSection QueuingCourseSection { get; set; } = null!;
}
