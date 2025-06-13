using AutoMapper;
using DUPSS.Application.Features.Blogs.Commands.Create;
using DUPSS.Application.Features.Blogs.Commands.Update;
using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;

namespace DUPSS.Application.Mapper
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
     
            CreateMap<Blog, GetAllBlogsResponse>();
            CreateMap<Blog, GetBlogResponse>();


            CreateMap<PagedResult<Blog>, PagedResult<GetAllBlogsResponse>>();


            CreateMap<CreateBlogCommand, Blog>();
            CreateMap<UpdateBlogCommand, Blog>()  
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
