using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Courses;
using DUPSS.Domain.Abstractions.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DUPSS.Application.Mapper;

public class CourseProfile : AutoMapper.Profile
{
    public CourseProfile()
    {
        CreateMap<Course, DUPSS.Application.Models.Courses.GetAllCoursesResponse>();
        CreateMap<PagedResult<Course>, PagedResult<GetAllCoursesResponse>>();
    }
}
