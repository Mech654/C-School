namespace Interfaces.Weapons;

public class Staff : IWeapon, IUpgradeable
{
    public int MagicPower { get; private set; } = 8;

    public int Attack()
    {
        int damage = MagicPower;
        Console.WriteLine($"Staff casts a spell for {damage} magic damage!");
        return damage;
    }

    public void Upgrade()
    {
        MagicPower += 3;
        Console.WriteLine($"Staff upgraded! New magic power: {MagicPower}");
    }
}