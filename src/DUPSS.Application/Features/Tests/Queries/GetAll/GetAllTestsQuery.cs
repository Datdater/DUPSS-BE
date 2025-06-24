using DUPSS.Application.Models.Tests;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DUPSS.Application.Features.Tests.Queries.GetAll
{
    public record GetAllTestsQuery : IQuery<PagedResult<GetAllTestsResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        // Test.Name hoặc Workshop.Title
        public string? Search { get; set; }

        // "StartDate", "EndDate"
        public string? SortBy { get; set; }

        // "asc" hoặc "desc"
        public string? SortOrder { get; set; }

        // key: TestCategory
        public Dictionary<string, string> Filters { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }
}
