using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DUPSS.Application.Abtractions;
using DUPSS.Application.Models.Auth;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using Microsoft.AspNetCore.Identity;

namespace DUPSS.Application.Features.Authentications.Commands.Login
{
    public class LoginHandler(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        ITokenService tokenService
    ) : ICommandHandler<LoginCommand, LoginResponse>
    {
        public async Task<Result<LoginResponse>> Handle(
            LoginCommand request,
            CancellationToken cancellationToken
        )
        {
            AppUser? user;
            if (Regex.IsMatch(request.EmailOrUserName, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                user = await userManager.FindByEmailAsync(request.EmailOrUserName);
            }
            else
            {
                user = await userManager.FindByNameAsync(request.EmailOrUserName);
            }

            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            var resultOfSignIn = await signInManager.PasswordSignInAsync(
                user.UserName!,
                request.Password,
                false,
                true
            );
            if (resultOfSignIn.Succeeded)
            {
                // Add local login info
                var loginInfo = new UserLoginInfo("LocalLogin", user.Id.ToString(), "Local User");
                var existingLogin = await userManager.FindByLoginAsync(
                    "LocalLogin",
                    user.Id.ToString()
                );
                if (existingLogin == null)
                {
                    var addLoginResult = await userManager.AddLoginAsync(user, loginInfo);
                    if (!addLoginResult.Succeeded)
                    {
                        throw new InvalidOperationException(
                            $"Failed to add login info: {string.Join(", ", addLoginResult.Errors.Select(e => e.Description))}"
                        );
                    }
                }
                var roles = await userManager.GetRolesAsync(user);

                var role = roles.FirstOrDefault();
                var token = tokenService.GenerateAccessToken(user.Id, role);
                var refreshToken = tokenService.GenerateRefreshToken();
                // Add refresh token to user
                var userToken = userManager.SetAuthenticationTokenAsync(
                    user,
                    "LocalLogin",
                    "RefreshToken",
                    refreshToken
                );
                if (!userToken.Result.Succeeded)
                {
                    throw new InvalidOperationException(
                        $"Failed to add refresh token: {string.Join(", ", userToken.Result.Errors.Select(e => e.Description))}"
                    );
                }
                return Result.Success(
                    new LoginResponse
                    {
                        AccessToken = token,
                        RefreshToken = refreshToken,
                        User = new AccountResponse
                        {
                            UserId = user.Id,
                            Username = user.UserName!,
                            Email = user.Email!,
                        },
                    }
                );
            }
            if (resultOfSignIn.IsLockedOut)
            {
                throw new UnauthorizedAccessException(
                    "Your account has been locked due to multiple failed login attempts. Please try again later."
                );
            }
            if (resultOfSignIn.RequiresTwoFactor)
            {
                throw new InvalidOperationException(
                    "Your account requires two-factor authentication. Please complete the two-factor authentication process."
                );
            }
            if (resultOfSignIn.IsNotAllowed)
            {
                throw new InvalidOperationException(
                    "Your account is not allowed to sign in. Please contact support."
                );
            }
            throw new UnauthorizedAccessException(
                "Invalid login attempt. Please check your password."
            );
        }
    }
}
