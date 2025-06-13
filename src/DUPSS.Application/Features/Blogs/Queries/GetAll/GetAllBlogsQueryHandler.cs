using AutoMapper;
using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.Blogs.Queries.GetAll
{
    public class GetAllBlogsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetAllBlogsQuery, PagedResult<GetAllBlogsResponse>>
    {
        public async Task<Result<PagedResult<GetAllBlogsResponse>>> Handle(
            GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            var queryable = unitOfWork.Repository<Blog>().GetQueryable();

            //Search
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                queryable = queryable.Where(b =>
                    b.Title.Contains(request.Search) ||
                    (b.Description != null && b.Description.Contains(request.Search)) ||
                    (b.Content != null && b.Content.Contains(request.Search)));
            }

            //Filter
            if (request.Filters != null)
            {
                foreach (var filter in request.Filters)
                {
                    switch (filter.Key.ToLower())
                    {
                        case "authorid":
                            queryable = queryable.Where(b => b.AuthorId == filter.Value);
                            break;
                        case "title":
                            queryable = queryable.Where(b => b.Title.Contains(filter.Value));
                            break;
                    }
                }
            }

            //Sort
            var sortBy = request.SortBy?.ToLower();
            var sortOrder = request.SortOrder?.ToLower() == "desc" ? false : true;

            queryable = sortBy switch
            {
                "title" => sortOrder ? queryable.OrderBy(b => b.Title) : queryable.OrderByDescending(b => b.Title),
                "createdat" => sortOrder ? queryable.OrderBy(b => b.CreatedAt) : queryable.OrderByDescending(b => b.CreatedAt),
                "authorid" => sortOrder ? queryable.OrderBy(b => b.AuthorId) : queryable.OrderByDescending(b => b.AuthorId),
                _ => queryable.OrderByDescending(b => b.CreatedAt) // default
            };

            // Paging
            var pagedBlogs = await PagedResult<Blog>.CreateAsync(
                queryable,
                request.PageIndex,
                request.PageSize
            );

            var response = mapper.Map<PagedResult<GetAllBlogsResponse>>(pagedBlogs);
            return Result.Success(response);
        }
    }
}
