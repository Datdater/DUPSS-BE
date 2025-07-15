using DUPSS.Application.Features.TestQuestions.Commands.Create;
using DUPSS.Application.Features.TestQuestions.Commands.Update;
using DUPSS.Application.Features.TestQuestions.Queries.GetAllTestResult;
using DUPSS.Application.Features.TestQuestions.Queries.GetByTestId;
using DUPSS.Application.Features.TestQuestions.Queries.GetQuestionOptionTestResultById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestQuestionsController(IMediator mediator) : BaseAPIController
    {
        [HttpGet("results")]
        public async Task<IActionResult> GetAllTestResults([FromQuery] GetAllTestResultQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestQuestions([FromBody] CreateTestQuestionCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestQuestion(string id, [FromBody] UpdateTestQuestionCommand command)
        {
            command.Id = id;
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("option-results/{testResultsId}")]
        public async Task<IActionResult> GetQuestionOptionTestResultById(string testResultsId)
        {
            var query = new GetQuestionOptionTestResultByIdQuery { TestResultsId = testResultsId };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("option-results")]
        public async Task<IActionResult> CreateQuestionOptionTestResults([FromBody] CreateQuestionOptionTestResultCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{testId}")]
        public async Task<IActionResult> GetByTestId(string testId)
        {
            var query = new GetByTestIdQuery { TestId = testId };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
