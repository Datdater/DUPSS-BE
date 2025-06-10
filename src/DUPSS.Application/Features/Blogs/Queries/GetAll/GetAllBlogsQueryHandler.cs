using AutoMapper;
using DUPSS.Application.Exceptions;
using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.Blogs.Queries.GetAll
{
    public class GetAllBlogsQueryHandler : IQueryHandler<GetAllBlogsQuery, PagedResult<GetAllBlogsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllBlogsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PagedResult<GetAllBlogsResponse>>> Handle(
            GetAllBlogsQuery request,
            CancellationToken cancellationToken)
        {
            try
            { 
                var query = _unitOfWork.Repository<Blog>()
                    .GetQueryable();

                var pagedBlogs = await PagedResult<Blog>.CreateAsync(
                    query,
                    request.PageIndex,
                    request.PageSize);

                if (!pagedBlogs.Items.Any())
                {
                    return Result.Failure<PagedResult<GetAllBlogsResponse>>(
                        new Error("Blogs.NotFound", "No blogs found"));
                }

                var mappedItems = pagedBlogs.Items
                    .Select(blog => _mapper.Map<GetAllBlogsResponse>(blog))
                    .ToList();

                var result = PagedResult<GetAllBlogsResponse>.Create(
                    mappedItems,
                    pagedBlogs.PageIndex,
                    pagedBlogs.PageSize,
                    pagedBlogs.TotalCount);

                return Result.Success(result);
            }
            catch (ValidationException ex)
            {
                return Result.Failure<PagedResult<GetAllBlogsResponse>>(
                    new Error("Validation.Error", ex.Message));
            }
            catch (AutoMapperMappingException ex)
            {
                return Result.Failure<PagedResult<GetAllBlogsResponse>>(
                    new Error("Mapping.Error", "An error occurred while mapping blog data"));
            }
            catch (Exception ex) when (ex is not ValidationException)
            {
                return Result.Failure<PagedResult<GetAllBlogsResponse>>(
                    new Error("Blogs.QueryError", "An error occurred while retrieving blogs"));
            }
        }
    }
}