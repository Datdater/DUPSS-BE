﻿using AutoMapper;
using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.TestQuestions.Queries.GetAllTestResult
{
    public class GetAllTestResultQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetAllTestResultQuery, PagedResult<GetAllTestResultResponse>>
    {
        public async Task<Result<PagedResult<GetAllTestResultResponse>>> Handle(
            GetAllTestResultQuery request, CancellationToken cancellationToken)
        {
            IQueryable<TestResult> queryable = unitOfWork.Repository<TestResult>()
                .GetQueryable()
                .Include(tr => tr.User)
                .Include(tr => tr.Test);

            // Search by User.Name
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                queryable = queryable.Where(tr =>
                    tr.User != null &&
                    (tr.User.FirstName.Contains(request.Search) ||
                     tr.User.LastName.Contains(request.Search)));
            }

            // Filters
            if (!string.IsNullOrWhiteSpace(request.UserId))
            {
                queryable = queryable.Where(tr => tr.UserId == request.UserId);
            }

            if (!string.IsNullOrWhiteSpace(request.TestId))
            {
                queryable = queryable.Where(tr => tr.TestId == request.TestId);
            }

            if (request.SurveyType.HasValue)
            {
                queryable = queryable.Where(tr => tr.Test.SurveyType == request.SurveyType.Value);
            }

            if (request.Category.HasValue)
            {
                queryable = queryable.Where(tr => tr.Test.Category == request.Category.Value);
            }

            if (request.SeverityLevel.HasValue)
            {
                queryable = queryable.Where(tr => tr.SeverityLevel == request.SeverityLevel.Value);
            }


            // Sort
            var sortBy = request.SortBy?.ToLower();
            var isAsc = request.SortOrder?.ToLower() != "desc";

            queryable = sortBy switch
            {
                "takenat" => isAsc ? queryable.OrderBy(tr => tr.TakenAt) : queryable.OrderByDescending(tr => tr.TakenAt),
                "totalpoint" => isAsc ? queryable.OrderBy(tr => tr.TotalPoint) : queryable.OrderByDescending(tr => tr.TotalPoint),
                "severitylevel" => isAsc ? queryable.OrderBy(tr => tr.SeverityLevel) : queryable.OrderByDescending(tr => tr.SeverityLevel),
                _ => queryable.OrderByDescending(tr => tr.TakenAt)
            };

            // Paging
            var paged = await PagedResult<TestResult>.CreateAsync(
                queryable,
                request.PageIndex,
                request.PageSize
            );

            var response = mapper.Map<PagedResult<GetAllTestResultResponse>>(paged);
            return Result.Success(response);
        }
    }
}
