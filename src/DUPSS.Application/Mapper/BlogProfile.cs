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
     
            CreateMap<Blog, GetAllBlogsResponse>()
                    .ForMember(dest => dest.AuthorName, opt =>
                    opt.MapFrom(src => src.User != null ? $"{src.User.FirstName} {src.User.LastName}" : string.Empty));
            CreateMap<Blog, GetBlogResponse>()
                    .ForMember(dest => dest.AuthorName, opt =>
                    opt.MapFrom(src => src.User != null ? $"{src.User.FirstName} {src.User.LastName}" : string.Empty));


            CreateMap<PagedResult<Blog>, PagedResult<GetAllBlogsResponse>>();
               



            CreateMap<CreateBlogCommand, Blog>();
            CreateMap<UpdateBlogCommand, Blog>()  
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
