using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.TestQuestions.Commands.Update
{
    public class UpdateTestQuestionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : ICommandHandler<UpdateTestQuestionCommand>
    {
        public async Task<Result> Handle(UpdateTestQuestionCommand request, CancellationToken cancellationToken)
        {
            var questionRepo = unitOfWork.Repository<TestQuestion>();
            var optionRepo = unitOfWork.Repository<QuestionOption>();

            var question = await questionRepo.GetByIdAsync(request.Id);

            if (question == null)
                throw new Exception($"TestQuestion with Id {request.Id} not found.");

          
            question.Content = request.Content;
            question.Order = request.Order;

            await questionRepo.UpdateAsync(question);

   
            var existingOptions = (await optionRepo.GetAllAsync())
                .Where(o => o.QuestionId == question.Id)
                .ToList();

            foreach (var optionDto in request.Options)
            {
                if (!string.IsNullOrEmpty(optionDto.Id))
                {
                    // Update existing option
                    var existingOption = existingOptions.FirstOrDefault(o => o.Id == optionDto.Id);
                    if (existingOption != null)
                    {
                        existingOption.Content = optionDto.Content;
                        existingOption.Value = optionDto.Value;
                        await optionRepo.UpdateAsync(existingOption);
                    }
                }
                else
                {
                    // Create new option
                    var newOption = new QuestionOption
                    {
                        QuestionId = question.Id,
                        Content = optionDto.Content,
                        Value = optionDto.Value
                    };
                    await optionRepo.AddAsync(newOption);
                }
            }

            await unitOfWork.SaveChangesAsync();

            return Result.Success(true);
        }
    }
}
