namespace TaskManagement.Infrastructure.Dtos
{
    public class MailSettings
    {
        public required string Mail { get; set; } 
        public required string Password { get; set; }
        public required string Host { get; set; }
        public int Port { get; set; }
    }
}
