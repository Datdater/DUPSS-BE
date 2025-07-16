using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Accounts;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using Microsoft.AspNetCore.Identity;

namespace DUPSS.Application.Features.Accounts.Queries.GetAllConsultant
{
    public class GetAllConsultantHandler
        : IQueryHandler<GetAllConsultantQuery, List<GetAllConsultantResponse>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAllConsultantHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<List<GetAllConsultantResponse>>> Handle(
            GetAllConsultantQuery request,
            CancellationToken cancellationToken
        )
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync("Consultant");

            var consultants = usersInRole
                .Select(user => new GetAllConsultantResponse
                {
                    Id = user.Id,
                    FullName = user.GetUserFullname(),
                })
                .ToList();

            return Result.Success(consultants);
        }
    }
}
