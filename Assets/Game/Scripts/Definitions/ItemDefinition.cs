using UnityEngine;

public enum Rarity { Trash, Common, Rare, Epic, Legendary, Mythic, Godly }
public enum ItemType { Weapon, Tool, Food, Outfit, Accessory, Ammo }

[CreateAssetMenu(fileName = "ItemDefinition", menuName = "Game/Item")]
public class ItemDefinition : ScriptableObject
{
    public int id;
    public string itemName;
    public string description;
    public Rarity rarity;
    public ItemType type;
    public float basePrice;
}