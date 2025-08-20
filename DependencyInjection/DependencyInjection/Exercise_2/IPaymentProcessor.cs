namespace DependencyInjection.Exercise_2;

public interface IPaymentProcessor
{
    void Process(decimal amount);
}