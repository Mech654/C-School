namespace DependencyInjection.Exercise_3;

public class SmtpEmailSender : IEmailSender
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine("Connecting to SMTP server...");
        Thread.Sleep(500);
        Console.WriteLine($"SMTP: Sending email to {to}");
        Console.WriteLine($"SMTP: Subject: {subject}");
        Console.WriteLine($"SMTP: Body: {body}");
        Thread.Sleep(1000);
        Console.WriteLine("Email sent successfully via SMTP!");
    }
}