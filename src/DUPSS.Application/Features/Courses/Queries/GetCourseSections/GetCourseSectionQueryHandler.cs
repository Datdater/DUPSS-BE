using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DUPSS.Application.Models.CourseSections;
using DUPSS.Application.Models.Steps;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.Courses.Queries.GetCourseSections
{
    public class GetCourseSectionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IQueryHandler<GetCourseSectionQuery, List<GetCourseSectionResponse>>
    {
        public async Task<Result<List<GetCourseSectionResponse>>> Handle(
            GetCourseSectionQuery request,
            CancellationToken cancellationToken
        )
        {
            var courseSection = await unitOfWork
                .Repository<CourseSection>()
                .GetQueryable()
                .Include(x => x.Course)
                .Include(x => x.Steps)
                .Where(x => x.Course.Id == request.CourseId)
                .ToListAsync();
            var response = mapper.Map<List<GetCourseSectionResponse>>(courseSection);
            return Result.Success(response);
        }
    }
}
