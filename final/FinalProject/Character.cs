using System;

public abstract class Character
{
    protected string _name;
    protected int _health;

    public string Name
    {
        get {return _name;}
    }
    public int Health
    {
        get {return _health;}
    }

    public Character(string name, int health)
    {
        _name = name;
        _health = health;
    }

    public bool IsAlive()
    {
    return _health > 0;
    }

    public virtual void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health < 0)
        {
            _health = 0;
        }
    }

    public abstract int CalculateAttackDamage();
}