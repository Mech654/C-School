using System;

namespace Inheritence.Exercise_5;

public class Program
{
    public static void MainEx5(string[] args)
    {
        Warrior warrior = new Warrior("Thor", 100, 15);
        Mage mage = new Mage("Gandalf", 80, 20);

        Console.WriteLine("Battle begins!");
        Console.WriteLine($"{warrior.Name} (Health: {warrior.Health}) vs {mage.Name} (Health: {mage.Health})");
        Console.WriteLine();

        while (warrior.Health > 0 && mage.Health > 0)
        {
            // Warrior attacks mage
            int warriorDamage = warrior.Attack();
            mage.Health -= warriorDamage;
            Console.WriteLine($"{warrior.Name} attacks for {warriorDamage} damage!");
            Console.WriteLine($"{mage.Name} health: {mage.Health}");

            if (mage.Health <= 0)
            {
                Console.WriteLine($"{mage.Name} is defeated! {warrior.Name} wins!");
                break;
            }

            // Mage attacks warrior
            int mageDamage = mage.Attack();
            warrior.Health -= mageDamage;
            Console.WriteLine($"{mage.Name} attacks for {mageDamage} damage!");
            Console.WriteLine($"{warrior.Name} health: {warrior.Health}");

            if (warrior.Health <= 0)
            {
                Console.WriteLine($"{warrior.Name} is defeated! {mage.Name} wins!");
                break;
            }

            Console.WriteLine();
        }
    }
}