namespace Interfaces.Interfaces;

public class PayPalPayment : IPayment
{
    public void ProcessPayment(decimal amount)
    {
        // Logic to process credit card payment
        Console.WriteLine($"Processing credit card payment of {amount:C}");
    }
}
