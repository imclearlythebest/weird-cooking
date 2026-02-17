using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float balance;
    public ItemCollection inventory;
    public List<int> knownNpcs;

    public PlayerData()
    {
        balance = 500f;
        knownNpcs = new List<int>();
        inventory = new ItemCollection();

        var defaultItem = Resources.Load<ItemDefinition>("Items/item_apple");
        var defaultItemStack = new ItemStack(defaultItem, 5);
        inventory.Add(defaultItemStack);
    }
}
