using DUPSS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.TestQuestions
{
    public class GetAllTestResultResponse
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }

        public string TestId { get; set; }
        public string TestName { get; set; }
        public SurveyType SurveyType { get; set; }
        public TestCategory Category { get; set; }

        public DateTime? TakenAt { get; set; }
        public SeverityLevel? SeverityLevel { get; set; }
        public double? TotalPoint { get; set; }
        public string? Recommendation { get; set; }
    }
}
