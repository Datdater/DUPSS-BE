using AutoMapper;
using DUPSS.Application.Models.Tests;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Tests.Queries.GetAll
{
    public class GetAllTestsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetAllTestsQuery, PagedResult<GetAllTestsResponse>>
    {
        public async Task<Result<PagedResult<GetAllTestsResponse>>> Handle(
            GetAllTestsQuery request, CancellationToken cancellationToken)
        {
            // Khai báo kiểu IQueryable
            IQueryable<Test> queryable = unitOfWork.Repository<Test>()
                .GetQueryable()
                .Include(t => t.Workshop);

            // Search theo Test.Name và Workshop.Title
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.ToLower();
                queryable = queryable.Where(t =>
                    t.Name.ToLower().Contains(search) ||
                    (t.Workshop != null && t.Workshop.Title.ToLower().Contains(search)));
            }

            // Filter theo Category (nếu có)
            if (request.Category.HasValue)
            {
                queryable = queryable.Where(t => t.Category == request.Category.Value);
            }

            // Sort theo Workshop.StartDate hoặc EndDate
            var sortBy = request.SortBy?.ToLower();
            var sortOrder = request.SortOrder?.ToLower() == "desc" ? false : true;

            queryable = sortBy switch
            {
                "startdate" => sortOrder
                    ? queryable.OrderBy(t => t.Workshop!.StartDate)
                    : queryable.OrderByDescending(t => t.Workshop!.StartDate),

                "enddate" => sortOrder
                    ? queryable.OrderBy(t => t.Workshop!.EndDate)
                    : queryable.OrderByDescending(t => t.Workshop!.EndDate),

                _ => queryable.OrderByDescending(t => t.CreatedAt) 
            };

            // Paging
            var pagedTests = await PagedResult<Test>.CreateAsync(
                queryable,
                request.PageIndex,
                request.PageSize
            );

            var response = mapper.Map<PagedResult<GetAllTestsResponse>>(pagedTests);
            return Result.Success(response);
        }
    }
}
