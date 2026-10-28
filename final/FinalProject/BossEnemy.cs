using System;

public class BossEnemy : Enemy
{
    public BossEnemy() : base("Balrog", 100, 100, 25)
    {
        
    }

    public override int CalculateAttackDamage()
    {
        return 8;
    }
}