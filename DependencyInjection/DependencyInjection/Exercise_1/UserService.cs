namespace DependencyInjection.Exercise_1;

class UserService
{
    private readonly ILogger _logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

    public void Log(string message)
    {
        _logger.Log(message);
    }
}
