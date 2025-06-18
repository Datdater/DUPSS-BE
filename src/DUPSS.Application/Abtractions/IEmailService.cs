
using DUPSS.Application.Commons;

namespace DUPSS.Application.Abtractions;

public interface IEmailService
{
    Task SendEmailAysnc(MailRequest mailRequest);
}