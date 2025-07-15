using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.Tests.Commands.Create
{
    public class CreateTestCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : ICommandHandler<CreateTestCommand>
    {
        public async Task<Result> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var test = mapper.Map<Test>(request);
            await unitOfWork.Repository<Test>().AddAsync(test);
            await unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
