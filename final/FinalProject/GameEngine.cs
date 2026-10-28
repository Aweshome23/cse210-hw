using System;

public class GameEngine
{
    private Player _player;
    private BattleManager _battleManager;
    private int _currentFloor;

    public GameEngine(Player player)
    {
        _player = player;
        _battleManager = new BattleManager();
        _currentFloor = 1;
    }

    public void RunGame()
    {
        Console.WriteLine("=== Welcome to Moria! ===");

        while (_player.IsAlive())
        {
            Console.WriteLine($"\n--- Floor {_currentFloor} ---");
            Console.WriteLine($"Player: {_player.Name} | Weapon: {_player.GetWeaponName()} | Health: {_player.Health} HP | Gold: {_player.GetGold()}");
            Console.WriteLine("1. Fight Next Enemy");
            Console.WriteLine("2. Rest / Heal (Cost: 10 Gold)");
            Console.WriteLine("3. Visit Weapon Shop");
            Console.WriteLine("3. Quit Game");
            Console.Write("Choose an action: ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Enemy nextEnemy;
                if (_currentFloor % 5 == 0)
                {
                    Console.WriteLine("\n*** A fearsome Boss blocks your path! Prepare for battle! ***");
                    nextEnemy = new BossEnemy();
                }
                else
                {
                    nextEnemy = new GoblinEnemy();
                }
                
                _battleManager.StartBattle(_player, nextEnemy);

                if (_player.IsAlive())
                {
                    _currentFloor++;
                }
            }
            else if (choice == "2")
            {
                if (_player.SpendGold(10))
                {
                    _player.Heal(15);
                    Console.WriteLine($"You take a rest at camp and recover your strength.");
                    Console.WriteLine($"Current Health: {_player.Health} HP | Remaining Gold: {_player.GetGold()}");
                }
                else
                {
                    Console.WriteLine("You don't have enough gold! You need 10 gold to rest.");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("\n=== Weapon Shop ===");
                Console.WriteLine($"Your Gold: {_player.GetGold()}");
                Console.WriteLine("1. Iron Sword (+5 Damage) - 25 Gold");
                Console.WriteLine("2. Mithril Blade (+10 Damage) - 60 Gold");
                Console.WriteLine("3. Back to Dungeon");
                Console.Write("What would you like to buy? ");

                string shopChoice = Console.ReadLine();

                if (shopChoice == "1")
                {
                    if (_player.SpendGold(25))
                    {
                        _player.EquipWeapon(new Equipment("Iron Sword", 5));
                        Console.WriteLine("You purchased and equipped the Iron Sword!");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold!");
                    }
                }
                else if (shopChoice == "2")
                {
                    if (_player.SpendGold(60))
                    {
                        _player.EquipWeapon(new Equipment("Mithril Blade", 10));
                        Console.WriteLine("You purchased and equipped the Mithril Blade!");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough gold!");
                    }
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.");
            }
        }

        if (!_player.IsAlive())
        {
            Console.WriteLine("\nYour journey has come to an end. Game Over.");
        }
    }
}