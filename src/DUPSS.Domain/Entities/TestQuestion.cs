using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class TestQuestion : BaseEntity
{
    public string TestId { get; set; }
    public int Order { get; set; }
    public string? Content { get; set; }

    public string? CreatedBy { get; set; }
    public string? LastModifiedBy { get; set; }

    public Test? Test { get; set; }

    public ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();
}
