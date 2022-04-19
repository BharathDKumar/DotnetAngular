namespace DotnetAngular.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }
}
