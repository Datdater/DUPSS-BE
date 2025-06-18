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

namespace DUPSS.Application.Features.Blogs.Commands.Create
{
    public class CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
       : ICommandHandler<CreateBlogCommand>
    {
        public async Task<Result> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = mapper.Map<Blog>(request);
            await unitOfWork.Repository<Blog>().AddAsync(blog);
            await unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
