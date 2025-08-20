namespace DependencyInjection.Exercise_2;

public class CheckoutService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public CheckoutService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void ProcessOrder(decimal amount)
    {
        Console.WriteLine($"Starting checkout process for order amount: ${amount}");
        Console.WriteLine("Validating order...");

        // Process payment using injected processor
        _paymentProcessor.Process(amount);

        Console.WriteLine("Order completed successfully!");
    }
}