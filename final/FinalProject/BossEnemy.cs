using System;

public class Boss : Enemy
{
    public Boss() : base("Balrog", 100, 100)
    {
        
    }

    public override int CalculateAttackDamage()
    {
        return 20; // Example boss damage
    }
}