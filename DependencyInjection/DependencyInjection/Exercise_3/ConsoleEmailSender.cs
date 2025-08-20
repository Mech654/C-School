namespace DependencyInjection.Exercise_3;

public class ConsoleEmailSender : IEmailSender
{
    public void SendEmail(string to, string subject, string body)
    {
        Console.WriteLine("=== EMAIL SENT TO CONSOLE ===");
        Console.WriteLine($"To: {to}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Body: {body}");
        Console.WriteLine("==============================");
    }
}