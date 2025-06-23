//using AutoMapper;
//using DUPSS.Application.Models.CourseRegistrations;
//using DUPSS.Domain.Abstractions.Message;
//using DUPSS.Domain.Abstractions.Shared;
//using DUPSS.Domain.Repositories;
//using MediatR;

//namespace DUPSS.Application.Features.CourseRegistrations.Queries.GetAllCourseRegistration
//{
//    public class GetAllCourseRegistrationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetAllCourseRegistrationQuery, PagedResult<GetAllCoursesRegistrationResponse>>
//    {
//        public async Task<Result<PagedResult<GetAllCoursesRegistrationResponse>>> IRequestHandler<GetAllCourseRegistrationQuery, Result<PagedResult<GetAllCoursesRegistrationResponse>>>.Handle(GetAllCourseRegistrationQuery request, CancellationToken cancellationToken)
//        {
//            var queryable = unitOfWork.Repository<DUPSS.Domain.Entities.CourseRegistration>().GetQueryable()
//                .OrderByDescending(cr => cr.SellingDate)
//                .Where(cr => !cr.IsDeleted)
//                ;
//            if(!string.IsNullOrEmpty(request.SearchTerm))
//            {
//                queryable = queryable.Where(cr => cr.Course.CourseName.Contains(request.SearchTerm)
//                                                  );
//            }
//            var courseRegistrations = await PagedResult<DUPSS.Domain.Entities.CourseRegistration>.CreateAsync(queryable, request.PageNumber, request.PageSize);
//            var response = mapper.Map<PagedResult<GetAllCoursesRegistrationResponse>>(courseRegistrations);
//            return Result.Success(response);
//        }
//    }
    
//}
