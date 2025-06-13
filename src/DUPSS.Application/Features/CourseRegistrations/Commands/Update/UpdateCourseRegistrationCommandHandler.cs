using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.CourseRegistrations.Commands.Update
{
    public class UpdateCourseRegistrationCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<UpdateCourseRegistrationCommand>
    {
        public async Task<Result> Handle(UpdateCourseRegistrationCommand request, CancellationToken cancellationToken)
        {
            var courseRegistration = await unitOfWork.Repository<CourseRegistration>().GetByIdAsync(request.Id);
            if (courseRegistration == null)
                return Result.Failure(new Error("RegistrationNotFound", "The specified course registration was not found."));

            courseRegistration.CourseProgress = request.CourseProgress;
            courseRegistration.Status = request.Status;
            courseRegistration.CertificateFile = request.CertificateFile;

            await unitOfWork.Repository<CourseRegistration>().UpdateAsync(courseRegistration);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
