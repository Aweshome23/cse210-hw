using System;

public class BattleManager
{
    public void StartBattle(Player player, Enemy enemy)
    {
        while (player.IsAlive() && enemy.IsAlive())
        {
            int damageToEnemy = player.CalculateAttackDamage();
            enemy.TakeDamage(damageToEnemy);
            Console.WriteLine($"{player.Name} attacks {enemy.Name} for {damageToEnemy} damage!");

            if (enemy.IsAlive())
            {
                int damageToPlayer = enemy.CalculateAttackDamage();
                player.TakeDamage(damageToPlayer);
                Console.WriteLine($"{enemy.Name} attacks {player.Name} for {damageToPlayer} damage!");
            }

        }
        if (!player.IsAlive())
            {
                Console.WriteLine($"\n{player.Name} has fallen in battle... Game Over.");
            }
        else if (!enemy.IsAlive())
            {
                Console.WriteLine($"{enemy.Name} has been defeated!");

                int exp = enemy.GetExpReward();
                int gold = enemy.GetGoldReward();

                Console.WriteLine($"You gained {exp} EXP and {gold} Gold!");
                player.AddExp(exp);
                player.AddGold(gold);
            }
    }
}