using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DUPSS.Application.Models.Courses;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Courses.Queries.GetById
{
    public class GetCourseByIdQuery : ICommand<GetCourseResponse>
    {
        public string Id { get; set; }
    }
}
