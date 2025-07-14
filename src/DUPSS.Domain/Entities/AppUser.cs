using DUPSS.Domain.Commons;
using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;
using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Pending;
    public bool Gender { get; set; }
    public DateTime BirthDay { get; set; }

    public string GetUserFullname()
    {
        return $"{FirstName} {LastName}";
    }
}
