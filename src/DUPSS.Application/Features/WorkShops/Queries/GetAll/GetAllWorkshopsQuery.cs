using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;

public record GetAllWorkshopsQuery(
    int PageIndex = 1,
    int PageSize = 10,
    string? Search = null,
    string? SortBy = null,
    string? SortOrder = "desc",
    // Filters
    string? Host = null,
    bool? Status = null
) : IQuery<PagedResult<GetAllWorkshopsResponse>>;
