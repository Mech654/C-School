namespace DependencyInjection.Exercise_2;

public class FakePaymentProcessor : IPaymentProcessor
{
    public bool WasCalled { get; private set; }
    public decimal LastAmount { get; private set; }

    public void Process(decimal amount)
    {
        WasCalled = true;
        LastAmount = amount;
        Console.WriteLine($"FAKE: Processing payment of ${amount} (for testing)");
    }
}