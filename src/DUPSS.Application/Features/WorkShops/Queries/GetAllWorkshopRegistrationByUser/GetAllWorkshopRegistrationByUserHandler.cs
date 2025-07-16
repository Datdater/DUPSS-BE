using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.WorkShops.Queries.GetAllWorkshopRegistrationByUser
{
    public class GetAllWorkshopRegistrationByUserHandler(
        IUnitOfWork unitOfWork,
        IClaimService claimService
    ) : IQueryHandler<GetAllWorkshopRegistrationByUserQuery, PagedResult<GetAllWorkshopsResponse>>
    {
        public async Task<Result<PagedResult<GetAllWorkshopsResponse>>> Handle(
            GetAllWorkshopRegistrationByUserQuery request,
            CancellationToken cancellationToken
        )
        {
            var userId = claimService.GetCurrentUser;

            var query = unitOfWork
                .Repository<WorkshopRegistration>()
                .GetQueryable()
                .Include(x => x.Workshop)
                .Where(r => r.UserId == userId);

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(r =>
                    r.Workshop.Title.ToLower().Contains(request.Search.ToLower())
                    || r.Workshop.Description.ToLower().Contains(request.Search.ToLower())
                    || r.Workshop.Host.ToLower().Contains(request.Search.ToLower())
                );
            }

            if (request.StartDate.HasValue)
            {
                query = query.Where(r =>
                    DateOnly.FromDateTime(r.Workshop.StartDate) >= request.StartDate.Value
                );
            }

            query = query.OrderByDescending(r => r.Workshop.StartDate);

            var pagedRegistrations = await PagedResult<WorkshopRegistration>.CreateAsync(
                query,
                request.PageIndex,
                request.PageSize
            );

            // Map to response model
            var response = pagedRegistrations
                .Items.Select(r => new GetAllWorkshopsResponse(
                    Id: r.Workshop.Id,
                    Title: r.Workshop.Title,
                    Description: r.Workshop.Description,
                    ImageUrl: r.Workshop.ImageUrl,
                    StartDate: r.Workshop.StartDate,
                    EndDate: r.Workshop.EndDate,
                    Host: r.Workshop.Host,
                    Status: r.Workshop.Status
                ))
                .ToList();

            var pagedResponse = PagedResult<GetAllWorkshopsResponse>.Create(
                response,
                pagedRegistrations.PageIndex,
                pagedRegistrations.PageSize,
                pagedRegistrations.TotalCount
            );

            return Result.Success(pagedResponse);
        }
    }
}
