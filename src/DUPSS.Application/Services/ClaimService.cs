using System.Security.Claims;
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

        public string GetCurrentRole
        {
            get
            {
                var role = httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;
                return role ?? string.Empty;
            }
        }
    }
}
