using AutoMapper;
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
    public class CreateWorkshopCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : ICommandHandler<CreateWorkshopCommand>
    {
        public async Task<Result> Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
        {
            var workshop = mapper.Map<Workshop>(request);
            await unitOfWork.Repository<Workshop>().AddAsync(workshop);
            await unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
