namespace DependencyInjection.Exercise_2;

public class StripePaymentProcessor : IPaymentProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing payment of ${amount} through Stripe...");
        // Simulate processing
        Thread.Sleep(1000);
        Console.WriteLine("Payment processed successfully via Stripe!");
    }
}