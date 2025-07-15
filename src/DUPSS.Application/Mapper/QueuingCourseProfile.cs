using AutoMapper;
using DUPSS.Application.Models.QueuingCourses;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;

namespace DUPSS.Application.Mapper;

public class QueuingCourseProfile : Profile
{
    public QueuingCourseProfile()
    {
        CreateMap<QueuingCourse, GetAllQueuingCoursesResponse>();
        CreateMap<PagedResult<QueuingCourse>, PagedResult<GetAllQueuingCoursesResponse>>();
    }
}
