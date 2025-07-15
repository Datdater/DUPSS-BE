using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.TestQuestions.Commands.Create
{
    public class CreateTestQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : ICommandHandler<CreateTestQuestionCommand>
    {
        public async Task<Result> Handle(CreateTestQuestionCommand request, CancellationToken cancellationToken)
        {
            foreach (var questionDto in request.Questions)
            {
                var testQuestion = mapper.Map<TestQuestion>(questionDto);
                testQuestion.TestId = request.TestId;

                await unitOfWork.Repository<TestQuestion>().AddAsync(testQuestion);

                foreach (var optionDto in questionDto.Options)
                {
                    var questionOption = mapper.Map<QuestionOption>(optionDto);
                    questionOption.QuestionId = testQuestion.Id;

                    await unitOfWork.Repository<QuestionOption>().AddAsync(questionOption);
                }
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
