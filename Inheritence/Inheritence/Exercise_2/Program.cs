using System;
using System.Collections.Generic;

namespace Inheritence.Exercise_2
{
    public class Program
    {
        public static void MainEx2(string[] args)
        {
            List<Animal> animals = new List<Animal>
            {
                new Lion(),
                new Elephant(),
                new Parrot()
            };

            foreach (var animal in animals)
            {
                Console.WriteLine($"Animal: {animal.Name}");
                animal.MakeSound();
            }
        }
    }
}