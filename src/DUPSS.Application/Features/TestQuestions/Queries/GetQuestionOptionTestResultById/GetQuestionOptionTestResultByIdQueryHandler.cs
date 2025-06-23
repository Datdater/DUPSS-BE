using AutoMapper;
using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.TestQuestions.Queries.GetQuestionOptionTestResultById
{
    public class GetQuestionOptionTestResultByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetQuestionOptionTestResultByIdQuery, List<QuestionOptionTestResultResponse>>
    {
        public async Task<Result<List<QuestionOptionTestResultResponse>>> Handle(
            GetQuestionOptionTestResultByIdQuery request,
            CancellationToken cancellationToken)
        {
            var queryable = unitOfWork.Repository<QuestionOptionTestResult>()
                .GetQueryable()
                .Include(qotr => qotr.SelectedOption)
                    .ThenInclude(opt => opt.Question)
                .Where(qotr => qotr.TestResultsId == request.TestResultsId);

            var resultList = await queryable.ToListAsync(cancellationToken);

            var response = mapper.Map<List<QuestionOptionTestResultResponse>>(resultList);
            return Result.Success(response);
        }
    }
}
