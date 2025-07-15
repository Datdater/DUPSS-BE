using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Auth
{
    public class LoginResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public AccountResponse User { get; set; }
    }

    public class AccountResponse
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string? Name { get; set; }

        public string Role { get; set; }
    }
}
