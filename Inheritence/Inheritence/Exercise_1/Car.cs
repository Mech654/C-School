using System;

namespace Inheritence.Exercise_1
{
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }

        public override void Drive()
        {
            Console.WriteLine("The car is moving");
        }
    }
}