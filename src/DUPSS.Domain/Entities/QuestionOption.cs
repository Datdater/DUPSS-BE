using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities
{
    public class QuestionOption : BaseEntity
    {
        public string QuestionId { get; set; }
        public string? Content { get; set; }
        public int Value { get; set; }

        public TestQuestion? Question { get; set; }
    }
}
