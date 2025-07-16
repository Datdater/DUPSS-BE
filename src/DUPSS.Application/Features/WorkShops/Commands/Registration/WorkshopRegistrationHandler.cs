using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using static DUPSS.Domain.Exceptions.WorkShopException;

namespace DUPSS.Application.Features.WorkShops.Commands.Registration
{
    public class WorkshopRegistrationHandler(IUnitOfWork unitOfWork, IClaimService claimService)
        : ICommandHandler<WorkshopRegistrationCommand>
    {
        public async Task<Result> Handle(
            WorkshopRegistrationCommand request,
            CancellationToken cancellationToken
        )
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                var userId = claimService.GetCurrentUser;
                var workshop = await unitOfWork
                    .Repository<Workshop>()
                    .GetQueryable()
                    .FirstOrDefaultAsync(x => x.Id == request.WorkshopId, cancellationToken);
                if (workshop == null)
                {
                    throw new WorkShopNotFoundException(request.WorkshopId);
                }
                var registration = new WorkshopRegistration
                {
                    UserId = userId,
                    WorkshopId = request.WorkshopId,
                    Note = request.Note,
                };
                await unitOfWork.Repository<WorkshopRegistration>().AddAsync(registration);
                await unitOfWork.SaveChangesAsync();
                await unitOfWork.CommitTransactionAsync();
                return Result.Success();
            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackTransactionAsync();
                return Result.Failure(new Error("Error.RegistrationFailed", ex.Message));
            }
        }
    }
}
