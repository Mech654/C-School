namespace Interfaces.Vehicles;

public class Car : Vehicle, IDriveable
{
    public Car(string brand) : base(brand)
    {
    }

    public void Start()
    {
        Console.WriteLine($"{Brand} car engine started");
    }

    public void Stop()
    {
        Console.WriteLine($"{Brand} car engine stopped");
    }
}