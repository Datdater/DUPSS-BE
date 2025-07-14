using AutoMapper;
using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.Blogs.Queries.GetById
{
    public class GetBlogByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetBlogByIdQuery, GetBlogResponse>
    {
        public async Task<Result<GetBlogResponse>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var blog = await unitOfWork.Repository<Blog>().GetByIdAsync(request.Id);

            if (blog == null)
                throw new BlogException.BlogNotFoundException(request.Id);

            var response = mapper.Map<GetBlogResponse>(blog);
            return Result.Success(response);
        }
    }
}
