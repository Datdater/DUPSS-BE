using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.TestQuestions
{
    public class GetTestQuestionWithOptionsResponse
    {
        public string Id { get; set; } = default!;
        public string? Content { get; set; }
        public int Order { get; set; }

        public List<QuestionOptionResponse> Options { get; set; } = [];
    }
}
