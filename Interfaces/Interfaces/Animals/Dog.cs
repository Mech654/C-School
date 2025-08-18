namespace Interfaces.Animals;

public class Dog : IMakeSound, IFeedable
{
    public void MakeSound()
    {
        Console.WriteLine("Woof");
    }

    public void Feed()
    {
        Console.WriteLine("Dog is eating dog food");
    }
}