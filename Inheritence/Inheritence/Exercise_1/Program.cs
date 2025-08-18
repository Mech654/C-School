using System;

namespace Inheritence.Exercise_1
{
    public class Program
    {
        public static void MainEx1(string[] args)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.Brand = "Generic";
            vehicle.MaxSpeed = "100 km/h";
            vehicle.Drive();

            Car car = new Car();
            car.Brand = "Toyota";
            car.MaxSpeed = "180 km/h";
            car.NumberOfDoors = 4;
            car.Drive();

            Bicycle bicycle = new Bicycle();
            bicycle.Brand = "Trek";
            bicycle.MaxSpeed = "30 km/h";
            bicycle.HasBell = true;
            bicycle.Drive();
        }
    }
}