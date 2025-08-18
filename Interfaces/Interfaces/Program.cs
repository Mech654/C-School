using Interfaces.Vehicles;
using Interfaces.Animals;
using Interfaces.Weapons;

namespace Interfaces;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Vehicle Exercise (IDriveable) ===");

        // Create vehicles
        var car = new Car("BMW");
        var motorcycle = new Motorcycle("Harley Davidson");

        // List of driveable vehicles
        List<IDriveable> vehicles = new List<IDriveable> { car, motorcycle };

        // Start all vehicles
        StartAllVehicles(vehicles);

        Console.WriteLine();

        // Stop all vehicles
        foreach (var vehicle in vehicles)
        {
            vehicle.Stop();
        }

        Console.WriteLine("\n=== Animal Sound Exercise (IMakeSound) ===");

        // Create animals
        var dog = new Dog();
        var cat = new Cat();
        var cow = new Cow();

        // List of sound-making animals
        List<IMakeSound> animals = new List<IMakeSound> { dog, cat, cow };

        // Make all animals make sound
        foreach (var animal in animals)
        {
            animal.MakeSound();
        }

        Console.WriteLine("\n=== Feeding Exercise (IFeedable) ===");

        // Feed the pets (only dog and cat implement IFeedable)
        List<IFeedable> pets = new List<IFeedable> { dog, cat };

        foreach (var pet in pets)
        {
            pet.Feed();
        }

        Console.WriteLine("\n=== Weapon Exercise (IWeapon) ===");

        // Create weapons
        var sword = new Sword();
        var bow = new Bow();
        var staff = new Staff();

        // List of weapons
        List<IWeapon> weapons = new List<IWeapon> { sword, bow, staff };

        // Simulate attacks
        Console.WriteLine("Initial attacks:");
        foreach (var weapon in weapons)
        {
            weapon.Attack();
        }

        Console.WriteLine("\n=== Weapon Upgrade Exercise (IUpgradeable) ===");

        // Upgrade weapons
        List<IUpgradeable> upgradeableWeapons = new List<IUpgradeable> { sword, bow, staff };

        foreach (var weapon in upgradeableWeapons)
        {
            weapon.Upgrade();
        }

        Console.WriteLine("\nAttacks after upgrade:");
        foreach (var weapon in weapons)
        {
            weapon.Attack();
        }
    }

    // Extra method for starting all vehicles
    static void StartAllVehicles(List<IDriveable> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Start();
        }
    }
}