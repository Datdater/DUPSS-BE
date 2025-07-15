using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Enums;

namespace DUPSS.Application.Features.QueuingCourses.Commands.Approve;

public class ApproveQueuingCourseCommand : ICommand
{
    public string Code { get; set; } = string.Empty;
    public QueuingCourseStatus QueuingCourseStatus { get; set; } = QueuingCourseStatus.Approved;
}
