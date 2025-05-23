using DUPSS.Domain.Entities;
using DUPSS.Domain.Enums;
using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserStatus Status{ get; set; }
    public bool Gender { get; set; }
    public DateTime BirthDay { get; set; }
}