using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal;
using DUPSS.Application.Abtractions;
using DUPSS.Application.Commons;
using DUPSS.Domain.Abstractions.Message;
using DUPSS.Domain.Abstractions.Shared;
using DUPSS.Domain.Enums;
using DUPSS.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace DUPSS.Application.Features.Authentications.Commands.Register
{
    public class RegisterCommandHandler(
        IUnitOfWork unitOfWork,
        ITokenService tokenService,
        UserManager<AppUser> userManager,
        IEmailService emailService
    ) : ICommandHandler<RegisterCommand>
    {
        public async Task<Result> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            try
            {
                await unitOfWork.BeginTransactionAsync();

                if (request.Password != request.ConfirmPassword)
                {
                    throw new ArgumentException("Password and Confirm Password do not match.");
                }

                var newUser = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    PhoneNumber = request.PhoneNumber,
                    Gender = request.Gender,
                    BirthDay = request.BirthDay,
                };
                var result = await userManager.CreateAsync(newUser, request.Password);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    throw new InvalidOperationException($"{string.Join("; ", errors)}");
                }

                var roleResult = await userManager.AddToRoleAsync(newUser, request.Role.ToString());

                if (!roleResult.Succeeded)
                {
                    var errors = roleResult.Errors.Select(e => e.Description).ToList();
                    throw new InvalidOperationException(
                        $"Failed to assign role: {string.Join("; ", errors)}"
                    );
                }

                if (request.Role == Role.Member)
                {
                    var htmlContent = await GetHtmlContent(newUser.UserName);

                    await emailService.SendEmailAysnc(
                        new MailRequest
                        {
                            ToEmail = newUser.Email,
                            Subject = "Welcome to Dupss",
                            Body = htmlContent,
                        }
                    );
                }

                await unitOfWork.CommitTransactionAsync();
                return Result.Success();
            }
            catch (Exception)
            {
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        private static async Task<string> GetHtmlContent(string userName)
        {
            var templatePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Utils",
                "HtmlContent",
                "Register.html"
            );

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template file not found: {templatePath}");
            }

            var htmlTemplate = await File.ReadAllTextAsync(templatePath);

            var htmlContent = htmlTemplate
                .Replace("{{USER_NAME}}", userName)
                .Replace("{{PLATFORM_NAME}}", "Dupss")
                .Replace("{{CURRENT_YEAR}}", DateTime.UtcNow.Year.ToString())
                .Replace("{{CONFIRMATION_LINK}}", "https://www.google.com");

            return htmlContent;
        }
    }
}
