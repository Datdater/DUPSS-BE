using AutoMapper;
using DUPSS.Application.Features.QueuingCourses.Commands.Create;
using DUPSS.Application.Models.QueuingCourses;
using DUPSS.Domain.Entities;

namespace DUPSS.Application.Mapper;

public class QueuingCourseProfile : Profile
{
    public QueuingCourseProfile()
    {
        CreateMap<QueuingCourse, GetAllQueuingCoursesResponse>()
            .ForMember(des => des.CategoryName, src => src.MapFrom(a => a.Category.CateName))
            .ForMember(des => des.InstructorName, src => src.MapFrom(a => a.User.GetUserFullname()))
            .ForMember(des => des.Status, src => src.MapFrom(a => a.QueuingCourseStatus))
            .ForMember(des => des.Duration, src => src.MapFrom(a => a.TotalDuration));
        CreateMap<CreateQueuingCourseCommand, QueuingCourse>();
        CreateMap<CreateQueuingCourseSection, QueuingCourseSection>();
        CreateMap<CreateQueuingStep, QueuingStep>();
        CreateMap<QueuingCourse, Course>()
            .ForMember(
                dest => dest.CourseSections,
                src => src.MapFrom(c => c.QueuingCourseSections)
            );
        CreateMap<QueuingCourseSection, CourseSection>()
            .ForMember(dest => dest.Steps, src => src.MapFrom(c => c.Steps));
        CreateMap<QueuingStep, Step>().ReverseMap();
    }
}
