using System;

public class GoblinEnemy : Enemy
{
    public GoblinEnemy() : base("Goblin", 30, 15, 5)
    {
        
    }

    public override int CalculateAttackDamage()
    {
        return 5; // Example goblin damage
    }
}