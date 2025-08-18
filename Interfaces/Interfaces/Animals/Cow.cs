namespace Interfaces.Animals;

public class Cow : IMakeSound
{
    public void MakeSound()
    {
        Console.WriteLine("Moo");
    }
}