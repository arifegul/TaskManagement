namespace TaskManagement.Infrastructure.Dtos
{
    public class MailRequest
    {
        public required string ToEmail { get; set; }
        public required string Subject { get; set; }
        public required string Body { get; set; }
	}
}
