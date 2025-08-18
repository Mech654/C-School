using System;

namespace Inheritence.Exercise_1
{
    public class Bicycle : Vehicle
    {
        public bool HasBell { get; set; }

        public override void Drive()
        {
            Console.WriteLine("The bicycle is pedaling.");
        }
    }
}