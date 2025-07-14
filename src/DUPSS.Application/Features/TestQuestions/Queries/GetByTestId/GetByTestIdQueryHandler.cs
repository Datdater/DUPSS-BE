using AutoMapper;
using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.TestQuestions.Queries.GetByTestId;

public class GetByTestIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IQueryHandler<GetByTestIdQuery, List<GetTestQuestionWithOptionsResponse>>
{
    public async Task<Result<List<GetTestQuestionWithOptionsResponse>>> Handle(
        GetByTestIdQuery request,
        CancellationToken cancellationToken)
    {
        var testQuestionRepo = unitOfWork.Repository<TestQuestion>();

        var questions = await testQuestionRepo.GetQueryable()
            .Where(q => q.TestId == request.TestId)
            .Include(q => q.QuestionOptions)
            .OrderBy(q => q.Order)
            .ToListAsync(cancellationToken);

        var response = mapper.Map<List<GetTestQuestionWithOptionsResponse>>(questions);

        return Result.Success(response);
    }
}
