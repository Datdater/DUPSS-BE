using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using Microsoft.AspNetCore.Http;

namespace DUPSS.Application.Services
{
    public class ClaimService(IHttpContextAccessor httpContextAccessor) : IClaimService
    {
        public string GetCurrentUser
        {
            get
            {
                var userId = httpContextAccessor
                    .HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)
                    ?.Value;
                return userId ?? string.Empty;
            }
        }
    }
}
