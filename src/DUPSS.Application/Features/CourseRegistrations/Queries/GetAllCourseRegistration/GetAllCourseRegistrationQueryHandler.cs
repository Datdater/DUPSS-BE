using AutoMapper;
using DUPSS.Application.Models.CourseRegistrations;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.CourseRegistrations.Queries.GetAllCourseRegistration
{
	public class GetAllCourseRegistrationQueryHandler : IQueryHandler<GetAllCourseRegistrationQuery, PagedResult<GetAllCoursesRegistrationResponse>>
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public GetAllCourseRegistrationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
		}

		public async Task<Result<PagedResult<GetAllCoursesRegistrationResponse>>> Handle(GetAllCourseRegistrationQuery request, CancellationToken cancellationToken)
		{
			var queryable = unitOfWork.Repository<DUPSS.Domain.Entities.CourseRegistration>().GetQueryable()
				.OrderByDescending(cr => cr.SellingDate)
				.Where(cr => !cr.IsDeleted);

			if (!string.IsNullOrEmpty(request.SearchTerm))
			{
				queryable = queryable.Where(cr => cr.Course.CourseName.Contains(request.SearchTerm));
			}

			var courseRegistrations = await PagedResult<DUPSS.Domain.Entities.CourseRegistration>.CreateAsync(queryable, request.PageNumber, request.PageSize);
			var response = mapper.Map<PagedResult<GetAllCoursesRegistrationResponse>>(courseRegistrations);
			return Result.Success(response);
		}
	}
    
}
