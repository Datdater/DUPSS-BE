using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.TestQuestions.Commands.Create
{
    public class CreateQuestionOptionTestResultCommand : ICommand
    {
        public string TestId { get; set; } = default!;
        public string UserId { get; set; } = default!;
        public List<string> SelectedOptionIds { get; set; } = new();
    }
}
