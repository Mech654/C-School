using Microsoft.Extensions.DependencyInjection;
namespace DependencyInjection.Exercise_5;

public class GameRunner
{
    private readonly IGameEngine _gameEngine;

    public GameRunner(IGameEngine gameEngine)
    {
        _gameEngine = gameEngine;
    }

    public void Run()
    {
        _gameEngine.StartGame();
    }

}
