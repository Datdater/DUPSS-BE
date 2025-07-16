using System.ComponentModel.DataAnnotations;
using System.Data;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Enums;

namespace DUPSS.Application.Features.Authentications.Commands.Register
{
    public class RegisterCommand : ICommand
    {
        public required string Email { get; set; }

        public required string UserName { get; set; }
        public required string Password { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string? FirstName { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string? LastName { get; set; }

        [Phone]
        public required string PhoneNumber { get; set; }

        public DateOnly? BirthDay { get; set; }
        public required bool Gender { get; set; }

        public required Role Role { get; set; }
    }
}
