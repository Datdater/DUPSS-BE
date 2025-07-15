using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.TestQuestions
{
    public class TestQuestionRequest
    {
        public int Order { get; set; }
        public string? Content { get; set; }
        public List<QuestionOptionRequest> Options { get; set; } = [];
    }
}
