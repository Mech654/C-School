namespace Inheritence.Exercise_5;

public class Mage : Character
{
    public int Mana { get; set; }

    public Mage(string name, int health, int mana) : base(name, health)
    {
        Mana = mana;
    }

    public override int Attack()
    {
        return Mana / 2;
    }
}