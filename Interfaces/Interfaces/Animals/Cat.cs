namespace Interfaces.Animals;

public class Cat : IMakeSound, IFeedable
{
    public void MakeSound()
    {
        Console.WriteLine("Meow");
    }

    public void Feed()
    {
        Console.WriteLine("Cat is eating cat food");
    }
}