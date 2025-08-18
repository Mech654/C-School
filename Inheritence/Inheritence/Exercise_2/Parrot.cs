using System;

namespace Inheritence.Exercise_2
{
    public class Parrot : Animal
    {
        public override string Name { get; set; } = "Parrot";

        public override void MakeSound()
        {
            Console.WriteLine("Squawk");
        }
    }
}