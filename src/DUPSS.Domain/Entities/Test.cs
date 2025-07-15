using DUPSS.Domain.Commons;
using DUPSS.Domain.Enums;

namespace DUPSS.Domain.Entities
{
    public class Test : BaseEntity
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public TestCategory Category { get; set; }

        public string? WorkshopId { get; set; }

        public SurveyType SurveyType { get; set; } = SurveyType.None;

        public virtual Workshop? Workshop { get; set; }
    }
}
