using DUPSS.Domain.Enums;

namespace DUPSS.Application.Models.QueuingCourses;

public class GetAllQueuingCoursesResponse
{
    public string Id { get; set; } = string.Empty;
    public string CourseName { get; set; } = string.Empty;
    public string? CourseCode { get; set; }

    public string CategoryName { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;

    public QueuingCourseStatus Status { get; set; }
    public string? InstructorName { get; set; }
}
