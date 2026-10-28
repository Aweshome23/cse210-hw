using System;

public class Player : Character
{
    private int _gold;
    private int _exp;
    private int _level = 1;
    private int _expToLevel = 10;
    private Equipment _equippedWeapon;

    public Player(string name, int health) : base(name, health)
    {
        _exp = 0;
        _gold = 0;
        _equippedWeapon = new Equipment("Old Sword", 3);
    }

    public int GetGold()
    {
        return _gold;
    }

    public void AddExp(int amount)
    {
        _exp += amount;
        Console.WriteLine($"Gained {amount} EXP! ({_exp}/{_expToLevel})");

        while (_exp >= _expToLevel)
        {
            _exp -= _expToLevel;
            LevelUp();
        }
    }

        private void LevelUp()
    {
        _level++;
        _expToLevel += 1;
        
        Console.WriteLine($"\n*** LEVEL UP! You reached Level {_level}! ***");
        Console.WriteLine("Your attack power increased by 1!");
    }
    
    public void AddGold(int amount)
    {
        _gold += amount;
    }

    public void EquipWeapon(Equipment newWeapon)
    {
        _equippedWeapon = newWeapon;
    }

    public void Heal(int amount)
    {
        _health += amount;
    }

    public string GetWeaponName()
    {
        return _equippedWeapon.GetItemName();
    }

    public bool SpendGold(int amount)
    {
        if (_gold >= amount)
        {
            _gold -= amount;
            return true;
        }
        return false;
    }

    public override int CalculateAttackDamage()
    {
        int baseAttack = 5;
        int levelBonus = _level - 1;
        return baseAttack + levelBonus + _equippedWeapon.GetBonusDamage();
    }
}