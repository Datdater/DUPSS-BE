using AutoMapper;
using DUPSS.Application.Features.Tests.Commands.Create;
using DUPSS.Application.Models.Tests;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;


namespace DUPSS.Application.Mapper
{
    public class TestProfile : Profile
    {
        public TestProfile()
        {
            CreateMap<CreateTestCommand, Test>();

            CreateMap<Test, GetAllTestsResponse>()
                  .ForMember(dest => dest.WorkshopTitle, opt => opt.MapFrom(src => src.Workshop != null ? src.Workshop.Title : null))
                  .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()))
                   .ForMember(dest => dest.SurveyType, opt => opt.MapFrom(src => src.SurveyType.ToReadableString())); 

            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>))
                .ConvertUsing(typeof(PagedResultConverter<,>));

        }
    }
}
