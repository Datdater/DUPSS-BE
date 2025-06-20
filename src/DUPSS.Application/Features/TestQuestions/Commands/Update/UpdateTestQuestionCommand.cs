using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.TestQuestions.Commands.Update
{
    public class UpdateTestQuestionCommand : ICommand
    {
        public string Id { get; set; } = default!;
        public string? Content { get; set; }
        public int Order { get; set; }

        public List<QuestionOptionDto> Options { get; set; } = [];
    }

    public class QuestionOptionDto
    {
        public string? Id { get; set; } // Nếu có Id thì cập nhật, nếu không có thì thêm mới
        public string? Content { get; set; }
        public int Value { get; set; }
    }
}
