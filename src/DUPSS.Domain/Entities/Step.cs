using System.ComponentModel.DataAnnotations;
using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class Step : BaseEntity
{
    public int StepNumber { get; set; }

    public string StepSummary { get; set; }

    public string? Content { get; set; }

    public bool Status { get; set; }

    [MaxLength(500)]
    public string? Attachment { get; set; }

    public string CourseSectionId { get; set; }

    public int? Duration { get; set; }

    public bool Type { get; set; }

    public string? VideoURL { get; set; }

    // Navigation
    [ForeignKey("CourseSectionId")]
    public CourseSection CourseSection { get; set; }

    public ICollection<Comment> Comments { get; set; }
}
