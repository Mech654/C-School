namespace Interfaces.Weapons;

public class Bow : IWeapon, IUpgradeable
{
    private Random _random = new Random();
    private int _minDamage = 5;
    private int _maxDamage = 15;

    public int Attack()
    {
        int damage = _random.Next(_minDamage, _maxDamage + 1);
        Console.WriteLine($"Bow shoots an arrow for {damage} damage!");
        return damage;
    }

    public void Upgrade()
    {
        _minDamage += 2;
        _maxDamage += 3;
        Console.WriteLine($"Bow upgraded! New damage range: {_minDamage}-{_maxDamage}");
    }
}