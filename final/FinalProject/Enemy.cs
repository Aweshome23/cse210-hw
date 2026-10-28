using System;

public abstract class Enemy : Character
{
    protected int _expReward;
    protected int _goldReward;

    public Enemy(string name, int health, int expReward, int goldReward) : base(name, health)
    {
        _expReward = expReward;
        _goldReward = goldReward;

    }

    public int GetExpReward()
    {
        return _expReward;
    }

    public int GetGoldReward()
    {
        return _goldReward;
    }
}