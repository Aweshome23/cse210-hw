using System;

public class Goblin : Enemy
{
    public Goblin() : base("Goblin", 30, 15)
    {
        
    }

    public override int CalculateAttackDamage()
    {
        return 5; // Example goblin damage
    }
}