namespace DependencyInjection.Exercise_3;

public interface IEmailSender
{
    void SendEmail(string to, string subject, string body);
}