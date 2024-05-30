using TaskManagement.Infrastructure.Dtos;

namespace TaskManagement.Infrastructure.Services.Interface
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
