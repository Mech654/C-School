namespace DependencyInjection.Exercise_2;

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void Process(decimal amount)
    {
        Console.WriteLine($"Processing payment of ${amount} through PayPal...");
        // Simulate processing
        Thread.Sleep(1200);
        Console.WriteLine("Payment processed successfully via PayPal!");
    }
}