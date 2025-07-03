using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Enums;
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

        // Thay vì Filters
        public String? UserId { get; set; }
        public String? TestId { get; set; }
        public SurveyType? SurveyType { get; set; }
        public TestCategory? Category { get; set; }
        public SeverityLevel? SeverityLevel { get; set; }
    }

}
