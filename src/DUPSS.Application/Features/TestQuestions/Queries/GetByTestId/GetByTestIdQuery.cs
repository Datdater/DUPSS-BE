using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Abstractions.Message;
using System.Collections.Generic;

namespace DUPSS.Application.Features.TestQuestions.Queries.GetByTestId
{
    public class GetByTestIdQuery : IQuery<List<GetTestQuestionWithOptionsResponse>>
    {
        public string TestId { get; set; } = default!;
    }
}
