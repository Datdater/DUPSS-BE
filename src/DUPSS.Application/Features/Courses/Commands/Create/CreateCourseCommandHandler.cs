using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.Courses.Commands.Create
{
    public class CreateCourseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : ICommandHandler<CreateCourseCommand>
    {
        public Task<Result> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("This method is not implemented yet.");
        }
    }
}
