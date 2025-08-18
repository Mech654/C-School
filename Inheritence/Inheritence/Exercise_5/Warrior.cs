namespace Inheritence.Exercise_5;

public class Warrior : Character
{
    public int Strength { get; set; }

    public Warrior(string name, int health, int strength) : base(name, health)
    {
        Strength = strength;
    }

    public override int Attack()
    {
        return Strength * 2;
    }
}