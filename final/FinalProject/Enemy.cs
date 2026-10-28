using System;

public abstract class Enemy : Character
{
    protected int _expReward;

    public Enemy(string name, int health, int expReward) : base(name, health)
    {
        _expReward = expReward;
    }
}