using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NpcDefinition", menuName = "Game/NpcDefinition")]
public class NpcDefinition : ScriptableObject
{
    public int id;
    public string npcName;
    public string role;
    public List<string> introDialogue;
    public List<string> defaultDialogue;

    // Shop-related
    public bool hasShop;
    public Shop shop;
    [ContextMenu("Refresh Shop")]
    public void RefreshShop()
    {
        if (hasShop && shop == null)
        {
            shop = new Shop();
        }
        if (hasShop)
        {
            shop.GeneratePrices();
        }
        else
        {
            shop = null;
        }
    }
}
