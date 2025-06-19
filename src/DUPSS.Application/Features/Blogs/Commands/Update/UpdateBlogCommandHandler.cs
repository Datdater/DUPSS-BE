using AutoMapper;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Exceptions;
using DUPSS.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.Blogs.Commands.Update
{
    public class UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : ICommandHandler<UpdateBlogCommand>
    {
        public async Task<Result> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await unitOfWork.Repository<Blog>().GetByIdAsync(request.Id);

            if (blog == null)
                throw new BlogException.BlogNotFoundException(request.Id);

            blog.Title = request.Title;
            blog.Description = request.Description;
            blog.Content = request.Content;

            await unitOfWork.Repository<Blog>().UpdateAsync(blog);
            await unitOfWork.SaveChangesAsync();

            return Result.Success(true);
        }
    }
}
