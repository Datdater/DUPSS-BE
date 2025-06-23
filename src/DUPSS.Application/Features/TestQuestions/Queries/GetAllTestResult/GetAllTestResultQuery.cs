using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.TestQuestions.Queries.GetAllTestResult
{
    public class GetAllTestResultQuery : IQuery<PagedResult<GetAllTestResultResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public string? Search { get; set; } // FirstName, LastName

        public string? SortBy { get; set; } // TakenAt
        public string? SortOrder { get; set; } // asc / desc

        public Dictionary<string, string>? Filters { get; set; }
    }
}
