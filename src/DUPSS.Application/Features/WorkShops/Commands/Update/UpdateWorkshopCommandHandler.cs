using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.WorkShops.Commands.Update
{
    public class UpdateWorkshopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<UpdateWorkshopCommand>
    {
        public async Task<Result> Handle(UpdateWorkshopCommand request, CancellationToken cancellationToken)
        {
            var workshop = await unitOfWork.Repository<Workshop>().GetByIdAsync(request.Id);

            if (workshop == null)
                throw new WorkShopException.WorkShopNotFoundException(request.Id);

            mapper.Map(request, workshop);

            await unitOfWork.Repository<Workshop>().UpdateAsync(workshop);
            await unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
