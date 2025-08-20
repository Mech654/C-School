using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.Exercise_1;

namespace DependencyInjection.Exercise_3;

public class Exercise3
{
    public static void Run()
    {
        Console.WriteLine("Running Exercise 3 - Email Notification with Multiple Dependencies");

        string emailSender = "Smtp"; // or "Console"
        string logger = "Console"; // or "File"

        // Create a service collection
        var serviceCollection = new ServiceCollection();

        // Register the IEmailSender implementation
        serviceCollection.AddSingleton<IEmailSender>(sp =>
        {
            return emailSender switch
            {
                "Smtp" => new SmtpEmailSender(),
                "Console" => new ConsoleEmailSender(),
                _ => throw new ArgumentException("Unknown email sender")
            };
        });

        // Register the ILogger implementation
        serviceCollection.AddSingleton<ILogger>(sp =>
        {
            return logger switch
            {
                "Console" => new ConsoleLogger(),
                "File" => new FileLogger(),
                _ => throw new ArgumentException("Unknown logger")
            };
        });

        // Register NotificationService
        serviceCollection.AddSingleton<NotificationService>();

        // Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve the NotificationService and send email
        var notificationService = serviceProvider.GetRequiredService<NotificationService>();
        notificationService.SendWelcomeEmail("john.doe@example.com", "John Doe");
    }
}