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
            CreateMap<Workshop, GetWorkshopResponse>();
            CreateMap<PagedResult<Workshop>, PagedResult<GetAllWorkshopsResponse>>();

            CreateMap<CreateWorkshopCommand, Workshop>();
            CreateMap<UpdateWorkshopCommand, Workshop>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}

