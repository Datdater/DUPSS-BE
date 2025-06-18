using DUPSS.Domain.Commons;

namespace DUPSS.Domain.Entities;

public class QuestionOptionTestResult : BaseEntity
{
    public string TestResultsId { get; set; }
    public string SelectedOptionId { get; set; }

    public TestResult? TestResult { get; set; }
    public QuestionOption? SelectedOption { get; set; }
}
