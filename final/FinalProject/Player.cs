using System;

public class Player : Character
{
    private int _gold;

    public Player(string name, int health) : base(name, health)
    {
        _gold = 0;
    }

    public override int CalculateAttackDamage()
    {
        return 10; // Placeholder
    }
}