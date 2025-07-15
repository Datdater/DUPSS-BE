using AutoMapper;
using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.WorkShops.Queries.GetAll
{
    public class GetAllWorkshopRegistrationsQueryHandler(
         IUnitOfWork unitOfWork,
         IMapper mapper)
         : IQueryHandler<GetAllWorkshopRegistrationsQuery, PagedResult<GetAllWorkshopRegistrationsResponse>>
    {
        public async Task<Result<PagedResult<GetAllWorkshopRegistrationsResponse>>> Handle(
            GetAllWorkshopRegistrationsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<WorkshopRegistration> baseQuery = unitOfWork.Repository<WorkshopRegistration>()
              .GetQueryable()
              .Include(r => r.Workshop)
              .Include(r => r.User);

            // Search
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.ToLower();
                baseQuery = baseQuery.Where(r =>
                    (r.Workshop.Title != null && r.Workshop.Title.ToLower().Contains(search)) ||
                    (r.User.FirstName != null && r.User.FirstName.ToLower().Contains(search)) ||
                    (r.User.LastName != null && r.User.LastName.ToLower().Contains(search)));
            }

            // Filter
            if (!string.IsNullOrWhiteSpace(request.WorkshopId)) 
            {
                baseQuery = baseQuery.Where(r => r.WorkshopId == request.WorkshopId);
            }

            if (!string.IsNullOrWhiteSpace(request.UserId))
            {
                baseQuery = baseQuery.Where(r => r.UserId == request.UserId);
            }


            // Sort
            var sortBy = request.SortBy?.ToLower();
            var isAsc = request.SortOrder?.ToLower() != "desc";

            IQueryable<WorkshopRegistration> query = sortBy switch
            {
                "workshoptitle" => isAsc
                    ? baseQuery.OrderBy(r => r.Workshop.Title)
                    : baseQuery.OrderByDescending(r => r.Workshop.Title),

                "username" => isAsc
                    ? baseQuery.OrderBy(r => r.User.LastName).ThenBy(r => r.User.FirstName)
                    : baseQuery.OrderByDescending(r => r.User.LastName).ThenByDescending(r => r.User.FirstName),

                _ => baseQuery.OrderByDescending(r => r.CreatedAt)
            };

            // Paging
            var paged = await PagedResult<WorkshopRegistration>.CreateAsync(
                query,
                request.PageIndex,
                request.PageSize);

            var result = mapper.Map<PagedResult<GetAllWorkshopRegistrationsResponse>>(paged);
            return Result.Success(result);

        }
    }
}
