using System;

public abstract class Character
{
    protected string _name;
    protected int _health;

    public Character(string name, int health)
    {
        _name = name;
        _health = health;
    }

    public abstract int CalculateAttackDamage();
}