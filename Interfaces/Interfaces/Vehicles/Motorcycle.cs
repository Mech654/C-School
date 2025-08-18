namespace Interfaces.Vehicles;

public class Motorcycle : Vehicle, IDriveable
{
    public Motorcycle(string brand) : base(brand)
    {
    }

    public void Start()
    {
        Console.WriteLine($"{Brand} motorcycle roars to life");
    }

    public void Stop()
    {
        Console.WriteLine($"{Brand} motorcycle engine shuts down");
    }
}