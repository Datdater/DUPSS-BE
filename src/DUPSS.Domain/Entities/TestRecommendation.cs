using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class TestRecommendation : BaseEntity
{
    public int MinPoint { get; set; }
    public int MaxPoint { get; set; }
    public string? Level { get; set; }
    public string? Recommend { get; set; }
    public string TestId { get; set; }

    public Test? Test { get; set; }
}
