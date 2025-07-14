using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.TestQuestions.Commands.Create
{
    public class CreateQuestionOptionTestResultCommandHandler(IUnitOfWork unitOfWork)
        : ICommandHandler<CreateQuestionOptionTestResultCommand>
    {
        public async Task<Result> Handle(CreateQuestionOptionTestResultCommand request, CancellationToken cancellationToken)
        {
            var test = await unitOfWork.Repository<Test>().GetByIdAsync(request.TestId);
            if (test == null)
                return Result.Failure(Error.NullValue);

            if (test.Category != TestCategory.ASSIS && test.Category != TestCategory.CRAFFT)
                return Result.Failure(new Error("Validation", "Only ASSIS and CRAFFT tests are allowed"));

            var optionsRepo = unitOfWork.Repository<QuestionOption>();
            var allOptions = await optionsRepo.GetAllAsync();
            var selectedOptions = allOptions.Where(x => request.SelectedOptionIds.Contains(x.Id)).ToList();

            if (selectedOptions.Count != request.SelectedOptionIds.Count)
                return Result.Failure(new Error("Validation", "One or more selected options are invalid"));

            double totalPoint = selectedOptions.Sum(o => o.Value);

            var recRepo = unitOfWork.Repository<TestRecommendation>();
            var recommendations = await recRepo.GetAllAsync();
            var matchedRecommendation = recommendations
                .Where(r => r.TestId == request.TestId)
                .FirstOrDefault(r => totalPoint >= r.MinPoint && totalPoint <= r.MaxPoint);

            var severityLevel = ParseSeverityLevel(matchedRecommendation?.Level);

            var testResult = new TestResult
            {
                Id = Guid.NewGuid().ToString(),
                TestId = request.TestId,
                UserId = request.UserId,
                TakenAt = DateTime.UtcNow,
                TotalPoint = totalPoint,
                Recommendation = matchedRecommendation?.Recommend,
                SeverityLevel = severityLevel
            };

            await unitOfWork.Repository<TestResult>().AddAsync(testResult);

            foreach (var option in selectedOptions)
            {
                await unitOfWork.Repository<QuestionOptionTestResult>().AddAsync(new QuestionOptionTestResult
                {
                    TestResultsId = testResult.Id,
                    SelectedOptionId = option.Id
                });
            }

            await unitOfWork.SaveChangesAsync();

            return Result.Success();
        }

        private SeverityLevel? ParseSeverityLevel(string? level)
        {
            return Enum.TryParse<SeverityLevel>(level, true, out var parsed)
                ? parsed
                : null;
        }
    }
}
