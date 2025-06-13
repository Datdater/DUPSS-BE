using DUPSS.Application.Abtractions;
using DUPSS.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DUPSS.Application.Services.RoleSeeder;

public class RoleSeeder : IRoleSeeder
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleSeeder(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task SeedRolesAsync()
    {
        var roles = Enum.GetNames(typeof(Role));

        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        
        var existingRoles = await _roleManager.Roles.ToListAsync();
        foreach (var existingRole in existingRoles)
        {
            if (!roles.Contains(existingRole.Name))
            {
                await _roleManager.DeleteAsync(existingRole);
            }
        }
    }
}