using DependencyInjection.Exercise_1;

namespace DependencyInjection.Exercise_3;

public class NotificationService
{
    private readonly IEmailSender _emailSender;
    private readonly ILogger _logger;

    public NotificationService(IEmailSender emailSender, ILogger logger)
    {
        _emailSender = emailSender;
        _logger = logger;
    }

    public void SendWelcomeEmail(string userEmail, string userName)
    {
        _logger.Log("Starting to send welcome email...");

        string subject = "Welcome to our service!";
        string body = $"Hello {userName},\n\nWelcome to our amazing service! We're excited to have you on board.\n\nBest regards,\nThe Team";

        try
        {
            _emailSender.SendEmail(userEmail, subject, body);
            _logger.Log($"Welcome email sent successfully to {userEmail}");
        }
        catch (Exception ex)
        {
            _logger.Log($"Failed to send welcome email: {ex.Message}");
        }
    }

    public void SendNotification(string userEmail, string message)
    {
        _logger.Log("Sending notification email...");

        try
        {
            _emailSender.SendEmail(userEmail, "Notification", message);
            _logger.Log($"Notification sent successfully to {userEmail}");
        }
        catch (Exception ex)
        {
            _logger.Log($"Failed to send notification: {ex.Message}");
        }
    }
}