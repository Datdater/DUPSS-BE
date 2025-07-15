using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.TestQuestions.Queries.GetQuestionOptionTestResultById
{
    public class GetQuestionOptionTestResultByIdQuery : IQuery<List<QuestionOptionTestResultResponse>>
    {
        public string TestResultsId { get; set; } = default!;
    }
}
