using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DUPSS.Application.Models.WorkShops;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Features.WorkShops.Queries.GetById
{
    public class GetWorkshopByIdQueryHandler
        : IQueryHandler<GetWorkshopByIdQuery, GetWorkshopResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWorkshopByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetWorkshopResponse>> Handle(
            GetWorkshopByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var workshop = await _unitOfWork
                .Repository<Workshop>()
                .GetQueryable()
                .Include(w => w.Registrations) // Include registrations if needed
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (workshop == null)
            {
                throw new WorkShopException.WorkShopNotFoundException(request.Id);
            }

            var response = _mapper.Map<GetWorkshopResponse>(workshop);
            return Result.Success(response);
        }
    }
}
