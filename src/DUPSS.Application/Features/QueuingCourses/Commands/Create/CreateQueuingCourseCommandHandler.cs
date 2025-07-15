using AutoMapper;
using DUPSS.Application.Abtractions;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;

namespace DUPSS.Application.Features.QueuingCourses.Commands.Create;

public class CreateQueuingCourseCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IClaimService claimService
) : ICommandHandler<CreateQueuingCourseCommand>
{
    public async Task<Result> Handle(
        CreateQueuingCourseCommand request,
        CancellationToken cancellationToken
    )
    {
        await unitOfWork.BeginTransactionAsync();

        var userId = claimService.GetCurrentUser;

        var newQueuingCourse = mapper.Map<QueuingCourse>(request);

        newQueuingCourse.CreatedBy = userId;
        newQueuingCourse.CreatedAt = DateTime.Now;
        newQueuingCourse.CreatedDate = DateTime.Now;
        newQueuingCourse.UpdatedDate = DateTime.Now;

        newQueuingCourse.TotalSection = newQueuingCourse.QueuingCourseSections.Count;
        newQueuingCourse.TotalStep = newQueuingCourse.QueuingCourseSections.Sum(x =>
            x.Steps?.Count ?? 0
        );
        newQueuingCourse.TotalDuration = newQueuingCourse.QueuingCourseSections.Sum(x =>
            x.Steps?.Sum(a => a.Duration ?? 0) ?? 0
        );

        await unitOfWork.Repository<QueuingCourse>().AddAsync(newQueuingCourse);
        await unitOfWork.SaveChangesAsync();
        await unitOfWork.CommitTransactionAsync();

        return Result.Success();
    }
}
