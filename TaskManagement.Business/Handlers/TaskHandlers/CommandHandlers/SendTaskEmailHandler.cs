using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Business.Commands.TaskCommands;
using TaskManagement.Business.Shared;
using TaskManagement.Infrastructure.Dtos;
using TaskManagement.Infrastructure.Services.Interface;

namespace TaskManagement.Business.Handlers.TaskHandlers.CommandHandlers
{
    public class SendTaskEmailHandler(IMailService mailService, ILogger<SendTaskEmailHandler> logger) : IRequestHandler<SendTaskEmailCommand, Response<bool>>
    {
        private readonly IMailService _mailService = mailService;
        private readonly ILogger<SendTaskEmailHandler> _logger = logger;
        public async Task<Response<bool>> Handle(SendTaskEmailCommand request, CancellationToken cancellationToken)

        {
            MailRequest mail = new()
            {
                ToEmail = request.ToEmail,
                Subject = request.TaskName,
                Body = request.Body
            };

            try
            {
                await _mailService.SendEmailAsync(mail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR", mail.ToEmail, "Task");
                throw;
            }

            return Response<bool>.Success(true, 201);
        }
    }
}
