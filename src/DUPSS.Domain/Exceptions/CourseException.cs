using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Exceptions
{
    public static class CourseException
    {
        public class CourseNotFoundException : NotFoundException
        {
            public CourseNotFoundException(Guid courseId)
                : base($"Course with ID '{courseId}' not found.")
            {
            }
        }
    }
}
