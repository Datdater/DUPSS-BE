using AutoMapper;
using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Mapper
{
    public class BlogProfile : AutoMapper.Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, GetAllBlogsResponse>()
                .ConstructUsing(src => new GetAllBlogsResponse(
                    src.Id.ToString(),
                    src.Title,
                    src.Content,
                    src.Description,
                    src.AuthorId.ToString(),
                    src.CreatedAt));
        }
    }
}
