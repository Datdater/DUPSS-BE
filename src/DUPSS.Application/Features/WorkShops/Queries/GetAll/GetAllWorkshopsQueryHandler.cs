using AutoMapper;
using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.WorkShops.Queries.GetAll
{
    public class GetAllWorkshopsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
      : IQueryHandler<GetAllWorkshopsQuery, PagedResult<GetAllWorkshopsResponse>>
    {
        public async Task<Result<PagedResult<GetAllWorkshopsResponse>>> Handle(GetAllWorkshopsQuery request, CancellationToken cancellationToken)
        {
            var queryable = unitOfWork.Repository<Workshop>().GetQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                queryable = queryable.Where(w =>
                    w.Title.Contains(request.Search) ||
                    (w.Description != null && w.Description.Contains(request.Search)) ||
                    w.Host.Contains(request.Search));
            }

            // Filter
            if (!string.IsNullOrWhiteSpace(request.Host))
            {
                queryable = queryable.Where(w => w.Host.Contains(request.Host));
            }

            if (request.Status.HasValue)
            {
                queryable = queryable.Where(w => w.Status == request.Status.Value);
            }

            // Sort
            var sortBy = request.SortBy?.ToLower();
            var sortAsc = request.SortOrder?.ToLower() == "asc";

            queryable = sortBy switch
            {
                "title" => sortAsc ? queryable.OrderBy(w => w.Title) : queryable.OrderByDescending(w => w.Title),
                "startdate" => sortAsc ? queryable.OrderBy(w => w.StartDate) : queryable.OrderByDescending(w => w.StartDate),
                "enddate" => sortAsc ? queryable.OrderBy(w => w.EndDate) : queryable.OrderByDescending(w => w.EndDate),
                "host" => sortAsc ? queryable.OrderBy(w => w.Host) : queryable.OrderByDescending(w => w.Host),
                _ => queryable.OrderByDescending(w => w.CreatedAt)
            };

            // Paging
            var paged = await PagedResult<Workshop>.CreateAsync(queryable, request.PageIndex, request.PageSize);

            var result = mapper.Map<PagedResult<GetAllWorkshopsResponse>>(paged);
            return Result.Success(result);
        }
    }
}
