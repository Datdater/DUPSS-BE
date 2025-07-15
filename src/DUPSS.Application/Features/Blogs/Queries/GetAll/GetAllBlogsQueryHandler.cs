using AutoMapper;
using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Blogs.Queries.GetAll
{
    public class GetAllBlogsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetAllBlogsQuery, PagedResult<GetAllBlogsResponse>>
    {
        public async Task<Result<PagedResult<GetAllBlogsResponse>>> Handle(
            GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            // Bắt đầu query
            IQueryable<Blog> queryable = unitOfWork.Repository<Blog>()
                .GetQueryable()
                .Include(b => b.User);

            // Search
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                queryable = queryable.Where(b =>
                    b.Title.Contains(request.Search) ||
                    (b.Description != null && b.Description.Contains(request.Search)) ||
                    (b.Content != null && b.Content.Contains(request.Search)));
            }

            // Filter
            if (!string.IsNullOrWhiteSpace(request.AuthorId))
            {
                queryable = queryable.Where(b => b.AuthorId == request.AuthorId);
            }

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                queryable = queryable.Where(b => b.Title.Contains(request.Title));
            }

            // Sort
            var sortBy = request.SortBy?.ToLower();
            var sortOrder = request.SortOrder?.ToLower() == "desc" ? false : true;

            queryable = sortBy switch
            {
                "title" => sortOrder
                    ? queryable.OrderBy(b => b.Title)
                    : queryable.OrderByDescending(b => b.Title),

                "createdat" => sortOrder
                    ? queryable.OrderBy(b => b.CreatedAt)
                    : queryable.OrderByDescending(b => b.CreatedAt),

                "authorid" => sortOrder
                    ? queryable.OrderBy(b => b.AuthorId)
                    : queryable.OrderByDescending(b => b.AuthorId),

                _ => queryable.OrderByDescending(b => b.CreatedAt)
            };

            // Phân trang
            var pagedBlogs = await PagedResult<Blog>.CreateAsync(
                queryable,
                request.PageIndex,
                request.PageSize
            );

            var mappedItems = mapper.Map<List<GetAllBlogsResponse>>(pagedBlogs.Items);

            var response = new PagedResult<GetAllBlogsResponse>(
                mappedItems,
                pagedBlogs.PageIndex,
                pagedBlogs.PageSize,
                pagedBlogs.TotalCount
            );

            return Result.Success(response);
        }
    }
}
