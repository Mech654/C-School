using Microsoft.Extensions.DependencyInjection;
namespace DependencyInjection.Exercise_5;

public class Exercise5
{
    public static void Run() // run this to start the game
    {
        Console.WriteLine("Running Exercise 5 - Game Engine with Dependency Injection");

        Console.Write("Choose a game to play: ");
        string game = Console.ReadLine()?.Trim() ?? string.Empty;
        // Create a service collection
        var serviceCollection = new ServiceCollection();

        // Register the IGameEngine implementation
        serviceCollection.AddSingleton<IGameEngine>(sp =>
        {
            return game switch
            {
                "GuessTheNumber" => new GuessNumberGame(),
                "RockPaperScissors" => new RockPaperScissorsGame(),
                _ => throw new ArgumentException("Unknown game type")
            };
        });

        // Register GameRunner
        serviceCollection.AddSingleton<GameRunner>();

        // Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve the GameRunner and run the game
        var gameRunner = serviceProvider.GetRequiredService<GameRunner>();
        gameRunner.Run();
    }
}
