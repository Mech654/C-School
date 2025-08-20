using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Exercise_1;

public class Exercise1
{
    public static void Run()
    {
        Console.WriteLine("Running Exercise 1 - Basic Dependency Injection");

        var serviceCollection = new ServiceCollection(); // initialize the service collection
        serviceCollection.AddScoped<ILogger, ConsoleLogger>(); // Use ConsoleLogger for ILogger
        serviceCollection.AddScoped<UserService>(); // Add the main class you want to use
        var serviceProvider = serviceCollection.BuildServiceProvider(); // Bake the cake
        var userService = serviceProvider.GetRequiredService<UserService>(); // Get the final usable output
        userService.Log("Hello from UserService!"); // use the service
    }

    private static void log(UserService userService, string message)
    {
        userService.Log(message);
    }
}