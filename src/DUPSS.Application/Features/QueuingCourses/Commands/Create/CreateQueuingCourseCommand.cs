using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.QueuingCourses.Commands.Create;

public class CreateQueuingCourseCommand : ICommand
{
    public string CourseName { get; set; } = string.Empty;
    public string CourseCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string PictureUrl { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public double Price { get; set; }
    public double OldPrice { get; set; }
    public string AttachmentUrl { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;

    public required ICollection<CreateQueuingCourseSection> QueuingCourseSections { get; set; } =
        [];
}

public class CreateQueuingCourseSection
{
    public int SectionNumber { get; set; }
    public string SectionName { get; set; } = string.Empty;

    public ICollection<CreateQueuingStep> Steps { get; set; } = [];
}

public class CreateQueuingStep
{
    public int StepNumber { get; set; }

    public string StepSummary { get; set; } = string.Empty;

    public string? Content { get; set; }

    public string? Attachment { get; set; }

    public int? Duration { get; set; }

    public bool Type { get; set; }

    public string? VideoURL { get; set; }
}
