using AutoMapper;
using DUPSS.Application.Features.WorkShops.Commands.Create;
using DUPSS.Application.Features.WorkShops.Commands.Update;
using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;

namespace DUPSS.Application.Mapper
{
    public class WorkShopProfile : Profile
    {
        public WorkShopProfile()
        {
            CreateMap<Workshop, GetAllWorkshopsResponse>();
            CreateMap<Workshop, GetWorkshopResponse>()
                .ForMember(
                    dest => dest.Registrations,
                    opt =>
                        opt.MapFrom(src =>
                            src.Registrations.Select(wr => new Registrations(
                                    wr.User.Id,
                                    wr.User.GetUserFullname()
                                ))
                                .ToList()
                        )
                )
                .ForMember(
                    dest => dest.TotalRegistrations,
                    opt => opt.MapFrom(src => src.Registrations.Count)
                );
            CreateMap<PagedResult<Workshop>, PagedResult<GetAllWorkshopsResponse>>();

            CreateMap<CreateWorkshopCommand, Workshop>();
            CreateMap<UpdateWorkshopCommand, Workshop>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<WorkshopRegistration, GetAllWorkshopRegistrationsResponse>()
                .ForMember(
                    dest => dest.WorkshopTitle,
                    opt => opt.MapFrom(src => src.Workshop.Title)
                )
                .ForMember(
                    dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User.LastName + " " + src.User.FirstName)
                );

            CreateMap<WorkshopRegistration, GetWorkshopRegistrationResponse>();
        }
    }
}
