using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.TestQuestions
{
    public class QuestionOptionTestResultResponse
    {
        public string QuestionId { get; set; } = default!;
        public string? QuestionContent { get; set; }
        public string SelectedOptionId { get; set; } = default!;
        public string? SelectedOptionContent { get; set; }
        public int SelectedOptionValue { get; set; }
    }
}
