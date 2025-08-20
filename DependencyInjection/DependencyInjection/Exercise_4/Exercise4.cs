using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Exercise_4;

public class Exercise4
{
    public static void Run()
    {
        Console.WriteLine("Running Exercise 4 - Product Repository with Dependency Injection");

        string repository = "InMemory"; // or "Sql"

        // Create a service collection
        var serviceCollection = new ServiceCollection();

        // Register the IProductRepository implementation
        serviceCollection.AddSingleton<IProductRepository>(sp =>
        {
            return repository switch
            {
                "InMemory" => new InMemoryProductRepository(),
                "Sql" => new SqlProductRepository(),
                _ => throw new ArgumentException("Unknown repository type")
            };
        });

        // Register ProductService
        serviceCollection.AddSingleton<ProductService>();

        // Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve the ProductService and use it
        var productService = serviceProvider.GetRequiredService<ProductService>();
        productService.DisplayAllProducts();
        productService.AddNewProduct("Monitor");
        productService.DisplayAllProducts();
    }
}