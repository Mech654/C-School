using Microsoft.Extensions.DependencyInjection;
namespace DependencyInjection.Exercise_2;

public class Exercise2
{
    public static void Run()
    {
        Console.WriteLine("Running Exercise 2 - Payment Processor with Dependency Injection");

        string processor = "Stripe"; // or "PayPal"

        // Create a service collection
        var serviceCollection = new ServiceCollection();

        // Register the IPaymentProcessor implementation
        serviceCollection.AddSingleton<IPaymentProcessor>(sp =>
        {
            return processor switch
            {
                "Stripe" => new StripePaymentProcessor(),
                "PayPal" => new PayPalPaymentProcessor(),
                _ => throw new ArgumentException("Unknown payment processor")
            };
        });

        // Register CheckoutService
        serviceCollection.AddSingleton<CheckoutService>();

        // Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve the CheckoutService and process order
        var checkoutService = serviceProvider.GetRequiredService<CheckoutService>();
        checkoutService.ProcessOrder(99.99m);
    }
}