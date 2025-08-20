using DependencyInjection.Exercise_1;
using DependencyInjection.Exercise_2;
using DependencyInjection.Exercise_3;
using DependencyInjection.Exercise_4;
using DependencyInjection.Exercise_5;

namespace DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        // ============================================
        // CHANGE THIS LINE TO RUN DIFFERENT EXERCISES
        // ============================================

        //Exercise1.Run();        // Uncomment this line to run Exercise 1
        //Exercise2.Run();
        //Exercise3.Run();
        //Exercise4.Run();
        Exercise5.Run();     // Uncomment this line to run Exercise 5

        // Add more exercises here as needed...

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
