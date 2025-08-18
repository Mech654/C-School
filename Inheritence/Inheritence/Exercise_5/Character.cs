namespace Inheritence.Exercise_5;

public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }

    public Character(string name, int health)
    {
        Name = name;
        Health = health;
    }

    public virtual int Attack()
    {
        return 10;
    }
}