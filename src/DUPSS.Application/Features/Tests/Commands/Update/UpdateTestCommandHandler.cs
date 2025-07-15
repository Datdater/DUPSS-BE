using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.Tests.Commands.Update
{
    public class UpdateTestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : ICommandHandler<UpdateTestCommand>
    {
        public async Task<Result> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            var test = await unitOfWork.Repository<Test>().GetByIdAsync(request.Id);

            if (test == null)
                throw new TestException.TestNotFoundException(request.Id);

            test.Name = request.Name;
            test.Category = request.Category;
            test.WorkshopId = request.WorkshopId;

            await unitOfWork.Repository<Test>().UpdateAsync(test);
            await unitOfWork.SaveChangesAsync();

            return Result.Success(true);
        }
    }
}
