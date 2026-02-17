[System.Serializable]
public class Shop
{
    public ItemCollection inventory;
    public float mult = 1.0f;

    public void GeneratePrices()
    {
        foreach (ItemStack i in inventory)
        {
            float newPrice = GeneratePrice(i, this);
            i.unitPrice = newPrice;
        }
    }

    public float GeneratePrice(ItemStack i, Shop shop)
    {
        return i.definition.basePrice * shop.mult;
    }
}
