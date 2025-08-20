namespace DependencyInjection.Exercise_1;

using System;

class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"FileLogger: {message}");
    }
}
