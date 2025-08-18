using System;

namespace Inheritence.Exercise_1
{
    public class Vehicle
    {
        public string Brand { get; set; }
        public string MaxSpeed { get; set; }

        public virtual void Drive()
        {
            Console.WriteLine("The vehicle is driving.");
        }
    }
}