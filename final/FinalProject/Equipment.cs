using System;

public class Equipment
{
    private string _itemName;
    private int _bonusDamage;

    public Equipment(string itemName, int bonusDamage)
    {
        _itemName = itemName;
        _bonusDamage = bonusDamage;
    }

    public string GetItemName()
    {
        return _itemName;
    }

    public int GetBonusDamage()
    {
        return _bonusDamage;
    }
}