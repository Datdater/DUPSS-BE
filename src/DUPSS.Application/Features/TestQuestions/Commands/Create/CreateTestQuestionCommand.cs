using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.TestQuestions.Commands.Create
{
    public class CreateTestQuestionCommand : ICommand
    {
        public string TestId { get; set; } = default!;
        public List<TestQuestionRequest> Questions { get; set; } = [];
    }

}
