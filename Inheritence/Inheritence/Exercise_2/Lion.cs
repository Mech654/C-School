using System;

namespace Inheritence.Exercise_2
{
    public class Lion : Animal
    {
        public override string Name { get; set; } = "Lion";

        public override void MakeSound()
        {
            Console.WriteLine("Roar");
        }
    }
}