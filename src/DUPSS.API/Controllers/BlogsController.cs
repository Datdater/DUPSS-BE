using DUPSS.Application.Features.Blogs.Queries.GetAll;
using DUPSS.Application.Models.Blogs;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DUPSS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly GetAllBlogsQueryHandler _getAllBlogsQueryHandler;

        public BlogsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _getAllBlogsQueryHandler = new GetAllBlogsQueryHandler(unitOfWork, mapper);
        }   

        [HttpGet]
        [ProducesResponseType(typeof(PagedResult<GetAllBlogsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var query = new GetAllBlogsQuery
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            var result = await _getAllBlogsQueryHandler.Handle(query, cancellationToken);

            if (!result.IsSuccess)
            {
                if (result.Error.Code == "Blogs.NotFound")
                    return NotFound(result.Error);

                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}