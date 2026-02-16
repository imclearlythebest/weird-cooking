using System.Collections.Generic;
// Item Definitions
public enum Rarity
{
    Trash,
    Common,
    Rare,
    Epic,
    Legendary,
    Mythic,
    Godly
}

public enum ItemType
{
    Weapon,
    Tool,
    Ingredient,
    Outfit,
    Accessory,
    Ammo
}
public class GameItem
{   
    public int id;
    public string name;
    public string description;
    public float basePrice;
    public Rarity rarity;
    public ItemType itemType;
}

public class ItemStack
{
    public GameItem item;
    public int quantity;
}
public class ItemCollection
{
    public List<ItemStack> items;
}

// NPC Definitions
public class NPC
{
    public int id; 
    public string name;
    public string description;
    public float inMult;
    public float outMult;
    public List<Item> favoriteItems;
    public List<Item> hatedItems;
    public List<ItemType> favoriteItemType;
    public List<ItemType> hatedItemType;
    public List<Rarity> rarities;


}