using DUPSS.Domain.Commons;
using DUPSS.Domain.Enums;

namespace DUPSS.Domain.Entities
{
    public class TestResult : BaseEntity
    {
        public string UserId { get; set; }
        public string TestId { get; set; }

        public DateTime? TakenAt { get; set; }
        public SeverityLevel? SeverityLevel { get; set; }

        public double? TotalPoint { get; set; }
        public string? Recommendation { get; set; }

        public Test? Test { get; set; }
        public AppUser? User {get;set;}
    }
}
