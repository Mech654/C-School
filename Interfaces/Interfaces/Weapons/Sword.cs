namespace Interfaces.Weapons;

public class Sword : IWeapon, IUpgradeable
{
    private int _damage = 10;

    public int Attack()
    {
        Console.WriteLine($"Sword slashes for {_damage} damage!");
        return _damage;
    }

    public void Upgrade()
    {
        _damage += 5;
        Console.WriteLine($"Sword upgraded! New damage: {_damage}");
    }
}