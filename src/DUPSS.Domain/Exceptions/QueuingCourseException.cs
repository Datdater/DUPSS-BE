namespace DUPSS.Domain.Exceptions;

public static class QueuingCourseException
{
    public class QueuingCourseNotFoundException : NotFoundException
    {
        public QueuingCourseNotFoundException(string courseCode)
            : base($"Queuing course with code '{courseCode}' not found.") { }
    }

    public class QueuingCourseAlreadyApprovedException : BadRequestException
    {
        public QueuingCourseAlreadyApprovedException(string courseCode)
            : base($"Queuing course with code '{courseCode}' is already approved.") { }
    }

    public class QueuingCourseAlreadyRejectedException : BadRequestException
    {
        public QueuingCourseAlreadyRejectedException(string courseCode)
            : base($"Queuing course with code '{courseCode}' is already rejected.") { }
    }
}
