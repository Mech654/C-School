using System;

namespace Inheritence.Exercise_2
{
    public class Elephant : Animal
    {
        public override string Name { get; set; } = "Elephant";

        public override void MakeSound()
        {
            Console.WriteLine("Trumpet");
        }
    }
}