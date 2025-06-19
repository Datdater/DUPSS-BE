using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.WorkShops.Commands.Create
{
    public class CreateWorkshopRegistrationCommandHandler(IUnitOfWork unitOfWork)
         : ICommandHandler<CreateWorkshopRegistrationCommand>
    {
        public async Task<Result> Handle(CreateWorkshopRegistrationCommand request, CancellationToken cancellationToken)
        {
            var entity = new WorkshopRegistration
            {
                Id = Guid.NewGuid().ToString(),
                WorkshopId = request.WorkshopId,
                UserId = request.UserId,
                Note = request.Note
            };

            await unitOfWork.Repository<WorkshopRegistration>().AddAsync(entity);
            await unitOfWork.SaveChangesAsync();

            return Result.Success(entity.Id);
        }
    }
}
