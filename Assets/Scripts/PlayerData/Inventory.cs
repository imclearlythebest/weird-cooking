using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public enum ItemType
    {
        Apple,
        Banana
    }

    public ItemType type;
    public int quantity;
}

[System.Serializable]
public class Inventory
{
    public List<Item> items = new List<Item>();
    public float balance = 100f;
}